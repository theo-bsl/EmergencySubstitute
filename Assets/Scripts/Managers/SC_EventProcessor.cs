using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SC_EventProcessor : MonoBehaviour
{
    public static SC_EventProcessor Instance;

    //SO_Character = Character, float = EventDuration, float = WorkTime
    private UnityEvent<SO_Character, float, float> m_updateCharacterWorkTime = new UnityEvent<SO_Character, float, float>();

    //SC_Event = Event (this event is used to update the character that is shown on the event in the map)
    private UnityEvent<SC_Event> m_updateCharacterAttribution = new UnityEvent<SC_Event>();

    //SO_Character = Character (this event greys out (or not) the character processing the event (or finishing))
    private UnityEvent<SO_Character> m_greyOutCharacter = new UnityEvent<SO_Character>();

    private bool m_isConfirming = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void GreyCharacter(SO_Character Character)
    {
        m_greyOutCharacter.Invoke(Character);
    }

    public void ProcessEvent(SC_Event Event, SO_Character Character)
    {
        if (Character != null)
        {
            if (Character.IsAvailable && !Event.IsGettingProcessed)
            {
                Event.IsGettingProcessed = true;
                StartCoroutine(Process(Event, Character));
            }
        }
    }

    private IEnumerator Process(SC_Event Event, SO_Character Character)
    {
        SC_CharacterManager.Instance.SelectCharacter(null);

        bool hasWrongExpertise;
        float ResolutionTime = Event.ResolutionTimer;

        switch (Event.Profession)
        {
            case Profession.Mechanic:
                ResolutionTime *= Character.Skills.Mechanic == Expertise.Average || Character.Skills.Mechanic == Expertise.Bad ? 1.5f : 1;
                hasWrongExpertise = Character.Skills.Mechanic == Expertise.Bad;
                break;
            case Profession.Informatician:
                ResolutionTime *= Character.Skills.Informatician == Expertise.Average || Character.Skills.Informatician == Expertise.Bad ? 1.5f : 1;
                hasWrongExpertise = Character.Skills.Informatician == Expertise.Bad;
                break;
            case Profession.Cook:
                ResolutionTime *= Character.Skills.Cook == Expertise.Average || Character.Skills.Cook == Expertise.Bad ? 1.5f : 1;
                hasWrongExpertise = Character.Skills.Cook == Expertise.Bad;
                break;
            case Profession.Doctor:
                ResolutionTime *= Character.Skills.Doctor == Expertise.Average || Character.Skills.Doctor == Expertise.Bad ? 1.5f : 1;
                hasWrongExpertise = Character.Skills.Doctor == Expertise.Bad;
                break;
            default:
                throw new Exception("The Event profession" + Event.Profession.ToString() + "isn't supported");
        }

        Character.WorkTime = ResolutionTime;
        
        while (Event != null && Character.WorkTime >= 0)
        {
            Character.WorkTime -= Time.deltaTime;

            m_updateCharacterWorkTime.Invoke(Character, ResolutionTime, Character.WorkTime);

            yield return null;
        }

        if (Event != null)
        {
            if (SC_EventManager.Instance.CheckIfCrisis(Event))
            {
                if (!hasWrongExpertise)
                {
                    SC_EventManager.Instance.DestroyEvent(Event);
                }
                else
                {
                    m_updateCharacterAttribution.Invoke(Event);
                }
            }
            else
            {
                if (hasWrongExpertise)
                {
                    SC_GameManager.Instance.Lose(Event.DeathCharacterPhrase);
                }
                else
                {
                    SC_EventManager.Instance.DestroyEvent(Event);
                }
            }
            Event.IsGettingProcessed = false;
        }
        m_greyOutCharacter.Invoke(Character);
        yield return null;
    }
    public UnityEvent<SO_Character, float, float> UpdateCharacterWorkTime { get { return m_updateCharacterWorkTime; } }
    public UnityEvent<SC_Event> UpdateCharacterAttribution {  get { return m_updateCharacterAttribution; } }
    public UnityEvent<SO_Character> GreyOutCharacter {  get { return m_greyOutCharacter; } }

    public bool IsConfirming { get { return m_isConfirming; } set { m_isConfirming = value; } }
}
