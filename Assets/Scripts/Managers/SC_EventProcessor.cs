using System;
using System.Collections;
using UnityEngine;

public class SC_EventProcessor : MonoBehaviour
{
    public void ProcessEvent(SC_Event Event, SO_Character Character)
    {
        if (Character.IsAvailable)
        {
            StartCoroutine(Process(Event, Character));
        }
    }

    private IEnumerator Process(SC_Event Event, SO_Character Character)
    {
        Character.WorkTime = Event.ResolutionTimer;

        //variable pour les differents cas d'expertises
        float multiplier = 1f;
        bool fail = false;

        //vérification d'un event crise (donc forcément finissable)
        bool canFinish = Event.HasTimer;

        //si l'event n'est pas une crise
        if (!canFinish)
        {
            //attribution des variables d'expertises
            switch (Event.Profession)
            {
                case SC_ProfessionEnum.Profession.Mechanic:
                    if (Character.m_skills.Mechanic == SC_ProfessionEnum.Expertise.Average)
                    {
                        multiplier = 1.5f;
                    }
                    else if (Character.m_skills.Mechanic == SC_ProfessionEnum.Expertise.Bad)
                    {
                        multiplier = 1.5f;
                        fail = true;
                    }
                    break;
                case SC_ProfessionEnum.Profession.Informatician:
                    if (Character.m_skills.Informatician == SC_ProfessionEnum.Expertise.Average)
                    {
                        multiplier = 1.5f;
                    }
                    else if (Character.m_skills.Informatician == SC_ProfessionEnum.Expertise.Bad)
                    {
                        multiplier = 1.5f;
                        fail = true;
                    }
                    break;
                case SC_ProfessionEnum.Profession.Cook:
                    if (Character.m_skills.Cook == SC_ProfessionEnum.Expertise.Average)
                    {
                        multiplier = 1.5f;
                    }
                    else if (Character.m_skills.Cook == SC_ProfessionEnum.Expertise.Bad)
                    {
                        multiplier = 1.5f;
                        fail = true;
                    }
                    break;
                case SC_ProfessionEnum.Profession.Doctor:
                    if (Character.m_skills.Doctor == SC_ProfessionEnum.Expertise.Average)
                    {
                        multiplier = 1.5f;
                    }
                    else if (Character.m_skills.Doctor == SC_ProfessionEnum.Expertise.Bad)
                    {
                        multiplier = 1.5f;
                        fail = true;
                    }
                    break;
                default:
                    throw new Exception("The Event profession" + Event.Profession.ToString() + "isn't supported");
            }

            //calcule du temps restant dans l'event
            float timeToFinish = Event.EndTimer - Time.time;

            //si le perso à assez de temps, alors arrêt du timer et attribution de canFinish à true
            if (timeToFinish >= Event.ResolutionTimer * multiplier)
            {
                Event.StopTimer();
                canFinish = true;
            }
        }

        //boucle d'attente de la résolution de l'event 
        while (Character.WorkTime > 0 && Event != null)//tant que le joueur doit attendre et que l'event existe
        {
            Character.WorkTime -= Time.deltaTime;
        }
        Character.WorkTime = 0;

        if (canFinish)
        {
            if (!fail)
            {
                //si le personnage fini l'event sans rater, il le détruit
                SC_EventManager.Instance.DestroyEvent(Event);
            }
            else if (Event.HasTimer)
            {
                //si le personnage rate, il déclenche le/les cas d'échecs
                Event.EndTimer = Time.time;
            }
        }
        yield return null;
    }
}
