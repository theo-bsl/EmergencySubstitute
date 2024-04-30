using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Problem", menuName = "ScriptableObjects/Problem", order = 1)]
public class SO_Problem : ScriptableObject
{
    [SerializeField]
    List<EventConfiguration> m_eventConfigurations = new List<EventConfiguration>();

    [SerializeField] 
    List<SC_Event> m_blockerEvents = new List<SC_Event>();

    public void ConfigureEvents()
    {
        for (int i = 0; i < m_eventConfigurations.Count; ++i)
        {
            m_eventConfigurations[i].SC_Event.EventAction = m_eventConfigurations[i].EventActions;
        }
    }


    public List<EventConfiguration> EventConfigurations {  get { return m_eventConfigurations; } }

    public List<SC_Event> BlockerEvents { get { return m_blockerEvents; } }
}
