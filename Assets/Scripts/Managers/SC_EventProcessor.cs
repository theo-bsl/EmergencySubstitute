using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class SC_EventProcessor : MonoBehaviour
{
    public static SC_EventProcessor Instance;

    public UnityEvent<SO_Character, float, float> m_updateCharacterWorkTime = new UnityEvent<SO_Character, float, float>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }    
    }

    public void ProcessEvent(SC_Event Event)
    {
        SO_Character Character = SC_CharacterManager.Instance.SelectedCharacter;
        if (Character.IsAvailable)
        {
            StartCoroutine(Process(Event, Character));
        }
    }

    private IEnumerator Process(SC_Event Event, SO_Character Character)
    {
        bool hasWrongExpertise;

        switch (Event.Profession)
        {
            case SC_ProfessionEnum.Profession.Mechanic:
                Event.ResolutionTimer *= Character.Skills.Mechanic == SC_ProfessionEnum.Expertise.Average || Character.Skills.Mechanic == SC_ProfessionEnum.Expertise.Bad ? 1.5f : 1;
                hasWrongExpertise = Character.Skills.Mechanic == SC_ProfessionEnum.Expertise.Bad;
                break;
            case SC_ProfessionEnum.Profession.Informatician:
                Event.ResolutionTimer *= Character.Skills.Informatician == SC_ProfessionEnum.Expertise.Average || Character.Skills.Informatician == SC_ProfessionEnum.Expertise.Bad ? 1.5f : 1;
                hasWrongExpertise = Character.Skills.Informatician == SC_ProfessionEnum.Expertise.Bad;
                break;
            case SC_ProfessionEnum.Profession.Cook:
                Event.ResolutionTimer *= Character.Skills.Cook == SC_ProfessionEnum.Expertise.Average || Character.Skills.Cook == SC_ProfessionEnum.Expertise.Bad ? 1.5f : 1;
                hasWrongExpertise = Character.Skills.Cook == SC_ProfessionEnum.Expertise.Bad;
                break;
            case SC_ProfessionEnum.Profession.Doctor:
                Event.ResolutionTimer *= Character.Skills.Doctor == SC_ProfessionEnum.Expertise.Average || Character.Skills.Doctor == SC_ProfessionEnum.Expertise.Bad ? 1.5f : 1;
                hasWrongExpertise = Character.Skills.Doctor == SC_ProfessionEnum.Expertise.Bad;
                break;
            default:
                throw new Exception("The Event profession" + Event.Profession.ToString() + "isn't supported");
        }

        Character.WorkTime = Event.ResolutionTimer;


        if (Event.HasTimer)
        {
            if (Event.ResolutionTimer + Time.time < Event.BeginningTimer + Event.EventDuration)
            {
                Event.StopTimer();
            }
        }
        
        while (Event != null && Character.WorkTime >= 0)
        {
            Character.WorkTime -= Time.deltaTime;
            m_updateCharacterWorkTime.Invoke(Character, Event.ResolutionTimer, Character.WorkTime);
            
            yield return null;
        }

        if (Event != null && hasWrongExpertise)
        {
            if (Event.GetType() == typeof(SC_EventFatal))
            {
                // game manager. game over
            }
            else
            {
                for (int i = 0; i < Event.ProvokedEvents.Count; i++)
                {
                    SC_EventManager.Instance.SpawnEvent(Event.ProvokedEvents[i]);
                }
            }
        }


        yield return null;
    }

    public UnityEvent<SO_Character, float, float> UpdateCharacterWorkTime { get { return m_updateCharacterWorkTime; } }
}
