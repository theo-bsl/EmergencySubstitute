using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SC_EventManager : MonoBehaviour
{
    public static SC_EventManager Instance;

    [SerializeField]
    private List<SC_Event> m_events = new List<SC_Event>();

    [SerializeField] private GameObject m_redAlert;
    [SerializeField] private GameObject m_orangeAlert;
    [SerializeField] private Animator m_apple;
    [SerializeField] private Animator m_screenShake;

    private int m_nbCrisisEvent = 0;
    private int m_nbFatalEvent = 0;
    private bool m_isRedAlert = false;

    //SC_Event = Event
    private UnityEvent<SC_Event> m_newEvent = new();

    //SC_Event = Event
    private UnityEvent<SC_Event> m_deleteEvent = new();

    private UnityEvent<string> m_gameOverEvent = new();


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SpawnEvent(SC_Event NewEvent)
    {
        if (NewEvent != null)
        {
            if (!IsEventInList(NewEvent))
            {
                float crisisTimePenalty = 0;

                switch (SC_CrisisGaugeManager.Instance.GetCrisisPercentage())
                {
                    case < 35:
                        crisisTimePenalty = 0;
                        break;
                    case < 65:
                        crisisTimePenalty = 15f;
                        break;
                    case < 100:
                        crisisTimePenalty = 35f;
                        break;
                    default:
                        //throw new Exception("Crisis Gauge too high ! ");
                        break;
                }

                

                SC_Event InstantiatedEvent = Instantiate(NewEvent);
                InstantiatedEvent.ResolutionTimer += InstantiatedEvent.ResolutionTimer * crisisTimePenalty / 100;
                m_events.Add(InstantiatedEvent);

                //verify if Instanciated Event Is Crisis
                
                if (CheckIfCrisis(InstantiatedEvent))
                {
                    m_nbCrisisEvent++;
                    if (InstantiatedEvent.Name == "système de gravité HS")
                    {
                        m_apple.SetTrigger("StartEvent");
                    }
                    if (!m_isRedAlert)
                    {
                        m_orangeAlert.SetActive(true);
                        SoundPlayer.instance.StartCrisesAlarm();
                    }
                }
                else
                {
                    m_nbFatalEvent++;
                    m_redAlert.SetActive(true);
                    SoundPlayer.instance.StartFatalAlarm();
                    m_orangeAlert.SetActive(false);
                    SoundPlayer.instance.EndCrisesAlarm();
                    m_isRedAlert = true;
                    if (InstantiatedEvent.Name == "Carlingue déchirée" ||  InstantiatedEvent.Name == "Moteurs détruit")
                    {
                        m_screenShake.SetBool("IsShaking", true);
                    }
                }

                if (InstantiatedEvent.IsVisible)
                {
                    m_newEvent.Invoke(InstantiatedEvent);
                }
                playSoundStartEvent(InstantiatedEvent);
            }
        }
    }

    public void playSoundStartEvent(SC_Event InstantiatedEvent)
    {
        SoundPlayer.instance.PlayPopup();

        if(InstantiatedEvent.Name == "manque de vitesse")
        {
            SoundPlayer.instance.MotorSlowSpeed();
        }
        else if (InstantiatedEvent.Name == "trop de vitesse")
        {
            SoundPlayer.instance.MotorFastSpeed();
        }
        else if (InstantiatedEvent.Name == "manque d'oxygène")
        {
            SoundPlayer.instance.StartHardBreathing();
        }
        else if (InstantiatedEvent.Name == "manque d'oxygène critique")
        {
            SoundPlayer.instance.StartVeryhardBreathing();
        }
        else if (InstantiatedEvent.Name == "Carlingue déchirée")
        {
            SoundPlayer.instance.PlayCarlingue();
        }
        else if (InstantiatedEvent.Name == "surpression critique")
        {
            SoundPlayer.instance.StartAcouphene();
        }
        else if (InstantiatedEvent.Name == "Faim")
        {
            SoundPlayer.instance.PlayHunger();
        }
        else if (InstantiatedEvent.Name == "Virus")
        {
            SoundPlayer.instance.StartHacking();
        }
        else if (InstantiatedEvent.Name == "Epidemie")
        {
            SoundPlayer.instance.PlayToussing();
        }
    }

    public void playSoundEndEvent(SC_Event InstantiatedEvent)
    {
        SoundPlayer.instance.PlayEndEvent();

        if (InstantiatedEvent.Name == "Virus")
        {
            SoundPlayer.instance.EndHacking();
        }
        else if (InstantiatedEvent.Name == "surpression critique")
        {
            SoundPlayer.instance.StopAcouphene();
        }
        else if (InstantiatedEvent.Name == "manque de vitesse" || InstantiatedEvent.Name == "trop de vitesse")
        {
            SoundPlayer.instance.MotorBaseSpeed();
        }
        else if (InstantiatedEvent.Name == "manque d'oxygène" || InstantiatedEvent.Name == "manque d'oxygène critique")
        {
            SoundPlayer.instance.StartNormalBreathing();
        }
    }

    public bool CheckIfCrisis(SC_Event Event)
    {
        for (int i = 0; i < Event.EventAction.Count; i++)
        {
            if (Event.EventAction[i].EventActionType == EventActionType.IncreaseGauge)
            {
                return true;
            }
        }
        return false;
    }

    private bool IsEventInList(SC_Event Event)
    {
        foreach (SC_Event Element in m_events)
        {
            if (Element.GetType() == NewEvent.GetType())
            {
                return true;
            }
        }
        return false;
    }

    private SC_Event PickEvent(List<Type> PoolOfEvent)
    {
        if (PoolOfEvent.Count > 0)
        {
            Type eventType = PoolOfEvent[UnityEngine.Random.Range(0, PoolOfEvent.Count)];
            SC_Event Event = (SC_Event)Activator.CreateInstance(eventType);
            
            if (IsEventInList(Event))
            {
                PoolOfEvent.Remove(eventType);
                Event = PickEvent(PoolOfEvent);
            }
            return Event;
        }
        return null;
    }

    private void ManageEndEvent(ResultEndEvent ResultEndEvent, SC_Event Event)
    {
        if (ResultEndEvent == ResultEndEvent.GameOver)
        {
            DestroyEvent(Event);
            m_gameOverEvent.Invoke(Event.DeathTimePhrase);
        }
    }

    public void DestroyEvent(SC_Event Event)
    {
        if (CheckIfCrisis(Event))
        {
            m_nbCrisisEvent--;
            m_orangeAlert.SetActive(false);
            SoundPlayer.instance.EndCrisesAlarm();
        }
        else
        {
            m_nbFatalEvent--;
        }

        if (Event.IsVisible)
        {
            m_deleteEvent.Invoke(Event);
        }
        m_events.Remove(Event);

        if (Event.Name == "système de gravité HS")
        {
            m_apple.SetTrigger("EndEvent");
        }
        else if (Event.Name == "Carlingue déchirée" || Event.Name == "Moteurs détruit")
        {
            m_screenShake.SetBool("IsShaking", false);
        }

        if (m_nbFatalEvent == 0)
        {
            m_redAlert.SetActive(false);
            SoundPlayer.instance.EndFatalAlarm();
        }
        playSoundEndEvent(Event);

        Destroy(Event);
    }

    public void FindAndDestroyEvent(SC_Event EventToDestroy)
    {
        SC_Event Event = null;

        for (int i = 0; i < m_events.Count; i++)
        {
            if (m_events[i].Name == EventToDestroy.Name)
            {
                Event = m_events[i];
                break;
            }
        }

        if (CheckIfCrisis(Event))
        {
            m_nbCrisisEvent--;
        }
        else
        {
            m_nbFatalEvent--;
        }

        if (Event.IsVisible)
        {
            m_deleteEvent.Invoke(Event);
        }

        if (m_nbFatalEvent == 0)
        {
            m_redAlert.SetActive(false);
        }

        m_events.Remove(Event);
        Destroy(Event);
    }

    private void Update()
    {
        for (int i = m_events.Count - 1; i >= 0; i--)
        {
            SC_Event Event = m_events[i];
            ResultEndEvent result = Event.UpdateEvent();
            ManageEndEvent(result, Event);
        }
    }
    
    public int NumberOfActiveCrisisEvent { get { return m_nbCrisisEvent; } }

    public UnityEvent<SC_Event> NewEvent { get { return m_newEvent; } }

    public UnityEvent<SC_Event> DeleteEvent { get { return m_deleteEvent; } }

    public UnityEvent<string> GameOverEvent { get { return m_gameOverEvent; } }
    
    public List<SC_Event> Events { get {  return m_events; } }
}
