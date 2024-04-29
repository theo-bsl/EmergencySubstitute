using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SC_GameManager : MonoBehaviour
{
    public static SC_GameManager Instance;
    [SerializeField]
    private List<int> m_timeline;
    private int m_indexTimeline = 0;
    private int m_nextTimeToSpawnEvent;
    private int m_maxOffsetTime;
    private SC_EventManager m_eventManager;
    private bool m_endGame = false;

    private UnityEvent<string> m_gameLose = new UnityEvent<string>();
    private UnityEvent m_gameWin = new UnityEvent();

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
        m_eventManager.GameOverEvent.AddListener(Lose);
        CalculateNextEventTime();
    }

    private void Update()
    {
        if (Time.time >= m_nextTimeToSpawnEvent && !m_endGame)
        {
            m_eventManager.SpawnEvent();
            if (m_indexTimeline < m_timeline.Count) 
            { 
                CalculateNextEventTime();
            }
            else
            {
                m_endGame = true;
            }
        }
    }

    private void CalculateNextEventTime()
    {
        int offSetTime = Random.Range(-m_maxOffsetTime, m_maxOffsetTime);
        
        m_nextTimeToSpawnEvent = m_timeline[m_indexTimeline] + Random.Range(-offSetTime, offSetTime);
        m_indexTimeline++;
    }

    public void Win()
    {
        PauseGame();
        m_gameWin.Invoke();
        //SceneManager.LoadScene("Win_Scene");
    }

    public void Lose(string LoseMessage)
    {
        PauseGame();
        m_gameLose.Invoke(LoseMessage);
        //SceneManager.LoadScene("Defeat_Scene");
    }

    public void PauseGame()
    {
        Time.timeScale = Time.timeScale > 0 ? 0 : 1;
    }

    public UnityEvent<string> GameLose { get {  return m_gameLose; } }
    public UnityEvent GameWin { get {  return m_gameWin; } }
}
