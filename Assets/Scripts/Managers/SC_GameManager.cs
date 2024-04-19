using System.Collections.Generic;
using UnityEngine;

public class SC_GameManager : MonoBehaviour
{
    [SerializeField]
    private List<int> m_timeline;
    private int m_indexTimeline = 0;
    private int m_nextTimeToSpawnEvent;
    private int m_maxOffsetTime;
    private SC_EventManager m_eventManager;

    private void Start()
    {
        m_eventManager = SC_EventManager.Instance;
        CalculateNextEventTime();
    }

    private void Update()
    {
        if (Time.time >= m_nextTimeToSpawnEvent)
        {
            m_eventManager.SpawnEvent();
        }
    }

    private void CalculateNextEventTime()
    {
        int offSetTime = Random.Range(0, m_maxOffsetTime);
        m_nextTimeToSpawnEvent = m_timeline[m_indexTimeline] + Random.Range(-offSetTime, offSetTime);
        m_indexTimeline++;
    }
}
