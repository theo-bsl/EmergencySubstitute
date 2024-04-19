using System;
using System.Collections.Generic;
using UnityEngine;

public class SC_EventManager : MonoBehaviour
{


    private List<SC_Event> m_events = new List<SC_Event>();

    private List<Type> m_eventFatalTypes = new List<Type>() 
    {
        typeof(SC_EventEpidemic), 
        typeof(SC_EventAutopilotHS),
        typeof(SC_EventLowCoolantLevel)
    };

    private List<Type> m_eventCrisisTypes = new List<Type>();

    private List<Type> m_eventDiscretTypes = new List<Type>();

    private int m_nbMaxEvent = 3;
    private int m_nbMaxFatalEvent = 3;
    private int m_nbMaxCrisisEvent = 3;
    private int m_nbMaxDiscretEvent = 3;

    private int m_nbFatalEvent = 0;
    private int m_nbCrisisEvent = 0;
    private int m_nbDiscretEvent = 0;

    public void SpawnEvent(SC_Event Event = null)
    {
        if (Event == null && m_events.Count < m_nbMaxEvent)
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
                PickEvent(PoolOfEvent);
            }
        }
        if (Event != null)
        {
            if (!m_events.Contains(Event))
            {
                ChangeEventNumber(Event);
                m_events.Add(Event);
            }
        }
    }

    private void ChangeEventNumber(SC_Event NewEvent, int value = 1)
    {
        if (NewEvent.GetType().IsSubclassOf(typeof(SC_EventFatal)))
        {
            m_nbFatalEvent += value;
        }
        /*
        if (NewEvent.GetType().IsSubclassOf(typeof(SC_EventCrisis)))
        {
            m_nbCrisisEvent += value;
        }
        if (NewEvent.GetType().IsSubclassOf(typeof(SC_EventDiscret)))
        {
            m_nbDiscretEvent += value;
        }
        */
    }

    private SC_Event PickEvent(List<Type> PoolOfEvent)
    {
        if (PoolOfEvent.Count > 0)
        {
            Type eventType = PoolOfEvent[UnityEngine.Random.Range(0, PoolOfEvent.Count)];
            SC_Event Event = (SC_Event)Activator.CreateInstance(eventType);
            if (m_events.Contains(Event))
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
            //GameOver
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
        ChangeEventNumber(Event, -1);
        m_events.Remove(Event);
    }

    private void Update()
    {
        foreach(SC_Event Event in m_events)
        {
            ResultEndEvent result = Event.UpdateEvent();
            ManageEndEvent(result, Event);
        }
    }
}
