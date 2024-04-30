using System;
using System.Collections.Generic;
using UnityEngine;

public class SC_ProblemsManager : MonoBehaviour
{
    public static SC_ProblemsManager Instance;

    [SerializeField]
    private List<SO_Problem> m_problems = new List<SO_Problem>();

    private bool m_hasBeenCreated = false;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void CreateProblem()
    {
        List<SO_Problem> PoolOfProblems = new List<SO_Problem>();
        PoolOfProblems.AddRange(m_problems);
        SO_Problem Problem = PickProblem(PoolOfProblems);
        if (Problem != null)
        {
            Problem.ConfigureEvents();
            for (int i = 0; i < Problem.EventConfigurations.Count; i++)
            {
                SC_EventManager.Instance.SpawnEvent(Problem.EventConfigurations[i].SC_Event);
            }


            //Chance to spawn a seconde problem
            bool m_shouldCreateAgain = false;

            switch (SC_CrisisGaugeManager.Instance.GetCrisisPercentage())
            {
                case < 25:
                    m_shouldCreateAgain = false;
                    break;
                case < 50:
                    m_shouldCreateAgain = UnityEngine.Random.Range(0, 100) < 16.6f;
                    break;
                case < 75:
                    m_shouldCreateAgain = UnityEngine.Random.Range(0, 100) < 33.2f;
                    break;
                case < 100:
                    m_shouldCreateAgain = UnityEngine.Random.Range(0, 100) < 50f;
                    break;
                default:
                    throw new Exception("Crisis Gauge too high ! ");
            }

            if (m_shouldCreateAgain && !m_hasBeenCreated)
            {
                m_hasBeenCreated = true;
                CreateProblem();
            }
        }
        m_hasBeenCreated = false;
    }

    private SO_Problem PickProblem(List<SO_Problem> PoolOfProblems)
    {
        SO_Problem NewProblem = null;
        if (PoolOfProblems.Count > 0)
        {
            NewProblem = PoolOfProblems[UnityEngine.Random.Range(0, PoolOfProblems.Count)];
            if (ProblemIsBlocked(NewProblem))
            {
                PoolOfProblems.Remove(NewProblem);
                NewProblem = PickProblem(PoolOfProblems);
            }
        }
        return NewProblem;
    }

    private bool ProblemIsBlocked(SO_Problem Problem)
    {
        List<SC_Event> BlockerEvents = Problem.BlockerEvents;
        List<SC_Event> ActiveEvents = SC_EventManager.Instance.Events;
        for (int i = 0; i < BlockerEvents.Count; i++)
        {
            for (int j = 0; j < ActiveEvents.Count; j++)
            {
                if (BlockerEvents[i].Name == ActiveEvents[j].Name)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
