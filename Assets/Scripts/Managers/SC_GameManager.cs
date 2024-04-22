using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_GameManager : MonoBehaviour
{
    public static SC_GameManager Instance;
    [SerializeField]
    private List<int> m_timeline;
    private int m_indexTimeline = 0;
    private int m_nextTimeToSpawnEvent;
    private int m_maxOffsetTime;
    private SC_EventManager m_eventManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
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
            CalculateNextEventTime();
        }
    }

    private void CalculateNextEventTime()
    {
        int offSetTime = Random.Range(-m_maxOffsetTime, m_maxOffsetTime);
        m_nextTimeToSpawnEvent = m_timeline[m_indexTimeline] + Random.Range(-offSetTime, offSetTime);
        m_indexTimeline++;
    }

    private void Win()
    {
        SceneManager.LoadScene("Win_Scene");
    }

    private void Lose()
    {
        SceneManager.LoadScene("Defeat_Scene");
    }
}
