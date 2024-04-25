using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SC_EventManager : MonoBehaviour
{
    public static SC_EventManager Instance;

    [SerializeField]
    private List<SC_Event> m_events = new List<SC_Event>();

    private List<Type> m_eventFatalTypes = new List<Type>() 
    {
        typeof(SC_EventEpidemic), 
        typeof(SC_EventAutopilotHS),
        typeof(SC_EventLowCoolantLevel),
        typeof(SC_ShipBodyBroke)
    };

    private List<Type> m_eventCrisisTypes = new List<Type>()
    {
        typeof(SC_EventHunger)
    };

    private List<Type> m_eventDiscretTypes = new List<Type>();

    private int m_nbMaxEvent = 5;
    private int m_nbMaxFatalEvent = 3;
    private int m_nbMaxCrisisEvent = 3;
    private int m_nbMaxDiscretEvent = 3;

    private int m_nbFatalEvent = 0;
    private int m_nbCrisisEvent = 0;
    private int m_nbDiscretEvent = 0;

    //SC_Event = Event
    private UnityEvent<SC_Event> m_newEvent = new();

    //SC_Event = Event
    private UnityEvent<SC_Event> m_deleteEvent = new();

    private bool m_isPairing = false;
    private bool m_hasSpawnPairingEvent = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void SpawnEvent(SC_Event NewEvent = null)
    {
        float crisisTimePenalty = 0;
        if (!m_isPairing)
        {
            if (SC_CrisisGaugeManager.Instance.GetCrisisPercentage() >= 25 && SC_CrisisGaugeManager.Instance.GetCrisisPercentage() < 50)
            {
                m_isPairing = UnityEngine.Random.Range(0, 100) <= 16.6f;
                crisisTimePenalty = 16.6f;
            }
            else if (SC_CrisisGaugeManager.Instance.GetCrisisPercentage() >= 50 && SC_CrisisGaugeManager.Instance.GetCrisisPercentage() < 75)
            {
                m_isPairing = UnityEngine.Random.Range(0, 100) <= 33.2f;
                crisisTimePenalty = 33.2f;
            }
            else if (SC_CrisisGaugeManager.Instance.GetCrisisPercentage() >= 75 && SC_CrisisGaugeManager.Instance.GetCrisisPercentage() < 100)
            {
                m_isPairing = UnityEngine.Random.Range(0, 100) <= 50f;
                crisisTimePenalty = 50f;
            }
        }

        if (NewEvent == null && m_events.Count < m_nbMaxEvent)
        {
            List<Type> PoolOfEvent = new List<Type>();
            if (m_nbFatalEvent < m_nbMaxFatalEvent)
            {
                PoolOfEvent.AddRange(m_eventFatalTypes);
            }
            if (m_nbCrisisEvent < m_nbMaxCrisisEvent)
            {
                PoolOfEvent.AddRange(m_eventCrisisTypes);
            }
            if (m_nbDiscretEvent < m_nbMaxDiscretEvent)
            {
                PoolOfEvent.AddRange(m_eventDiscretTypes);
            }

            if (PoolOfEvent.Count > 0)
            {
                NewEvent = PickEvent(PoolOfEvent);
            }
        }
        if (NewEvent != null)
        {
            NewEvent.ResolutionTimer += NewEvent.ResolutionTimer * crisisTimePenalty / 100;

            bool isInEventList = true;
            foreach (SC_Event Element in m_events)
            {
                if (Element.GetType() == NewEvent.GetType())
                {
                    isInEventList = false;
                    break;
                }
            }
            if (isInEventList)
            {
                ChangeEventNumber(NewEvent.GetType(), 1);
                m_events.Add(NewEvent);
                NewEvent.StartEvent();
                m_newEvent.Invoke(NewEvent);
            }
        }

        if (m_isPairing && !m_hasSpawnPairingEvent)
        {
            m_hasSpawnPairingEvent = true;
            SpawnEvent();
        }
        if (m_isPairing && m_hasSpawnPairingEvent)
        {
            m_isPairing = false;
            m_hasSpawnPairingEvent = false;
        }
    }


    private void ChangeEventNumber(Type EventType, int value)
    {
        m_nbFatalEvent += EventType.IsSubclassOf(typeof(SC_EventFatal)) ? value : 0;
        m_nbCrisisEvent += EventType.IsSubclassOf(typeof(SC_EventCrisis)) ? value : 0;
        m_nbDiscretEvent += EventType.IsSubclassOf(typeof(SC_EventDiscreet)) ? value : 0;
    }

    private SC_Event PickEvent(List<Type> PoolOfEvent)
    {
        if (PoolOfEvent.Count > 0)
        {
            Type eventType = PoolOfEvent[UnityEngine.Random.Range(0, PoolOfEvent.Count)];
            SC_Event Event1 = (SC_Event)Activator.CreateInstance(eventType);
            bool detect = true;
            foreach (SC_Event Element in m_events)
            {
                if (Element.GetType() == Event1.GetType())
                {
                    detect = false;
                    break;
                }
            }
            if (!detect)
            {
                PoolOfEvent.Remove(eventType);
                Event1 = PickEvent(PoolOfEvent);
            }
            return Event1;
        }
        return null;
    }

    private void ManageEndEvent(ResultEndEvent ResultEndEvent, SC_Event Event)
    {
        if (ResultEndEvent == ResultEndEvent.GameOver)
        {
            Debug.Log(Event.Name + " killed you !");
            DestroyEvent(Event);
            SC_GameManager.Instance.Lose();
        }
        else if (ResultEndEvent == ResultEndEvent.CreateEvent)
        {
            foreach (SC_Event spawnEvent in Event.ProvokedEvents)
            {
                SpawnEvent(spawnEvent);
            }
            DestroyEvent(Event);
        }
    }

    public void DestroyEvent(SC_Event Event)
    {
        m_deleteEvent.Invoke(Event);
        ChangeEventNumber(Event.GetType(), -1);
        m_events.Remove(Event);
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
}
