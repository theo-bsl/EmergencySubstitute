using System;
using System.Collections;
using UnityEngine;

public class SC_EventProcessor : MonoBehaviour
{
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
                Event.ResolutionTimer *= Character.m_skills.Mechanic == SC_ProfessionEnum.Expertise.Average || Character.m_skills.Mechanic == SC_ProfessionEnum.Expertise.Bad ? 1.5f : 1;
                hasWrongExpertise = Character.m_skills.Mechanic == SC_ProfessionEnum.Expertise.Bad;
                break;
            case SC_ProfessionEnum.Profession.Informatician:
                Event.ResolutionTimer *= Character.m_skills.Informatician == SC_ProfessionEnum.Expertise.Average || Character.m_skills.Informatician == SC_ProfessionEnum.Expertise.Bad ? 1.5f : 1;
                hasWrongExpertise = Character.m_skills.Informatician == SC_ProfessionEnum.Expertise.Bad;
                break;
            case SC_ProfessionEnum.Profession.Cook:
                Event.ResolutionTimer *= Character.m_skills.Cook == SC_ProfessionEnum.Expertise.Average || Character.m_skills.Cook == SC_ProfessionEnum.Expertise.Bad ? 1.5f : 1;
                hasWrongExpertise = Character.m_skills.Cook == SC_ProfessionEnum.Expertise.Bad;
                break;
            case SC_ProfessionEnum.Profession.Doctor:
                Event.ResolutionTimer *= Character.m_skills.Doctor == SC_ProfessionEnum.Expertise.Average || Character.m_skills.Doctor == SC_ProfessionEnum.Expertise.Bad ? 1.5f : 1;
                hasWrongExpertise = Character.m_skills.Doctor == SC_ProfessionEnum.Expertise.Bad;
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
}
