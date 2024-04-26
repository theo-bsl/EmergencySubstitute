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
        List<SO_Problem> PoolOfProblems = m_problems;
        SO_Problem Problem = PickProblem(PoolOfProblems);
        if (Problem != null)
        {
            for (int i = 0; i < Problem.Events.Count; i++)
            {
                SC_EventManager.Instance.SpawnEvent(Problem.Events[i]);
            }


            //Chance to spawn a seconde problem
            bool m_shouldCreateAgain = false;
            if (SC_CrisisGaugeManager.Instance.GetCrisisPercentage() >= 25 && SC_CrisisGaugeManager.Instance.GetCrisisPercentage() < 50)
            {
                m_shouldCreateAgain = Random.Range(0, 100) < 16.6f;
            }
            else if (SC_CrisisGaugeManager.Instance.GetCrisisPercentage() >= 50 && SC_CrisisGaugeManager.Instance.GetCrisisPercentage() < 75)
            {
                m_shouldCreateAgain = Random.Range(0, 100) < 33.2f;
            }
            else if (SC_CrisisGaugeManager.Instance.GetCrisisPercentage() >= 75 && SC_CrisisGaugeManager.Instance.GetCrisisPercentage() < 100)
            {
                m_shouldCreateAgain = Random.Range(0, 100) < 50f;
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
            NewProblem = PoolOfProblems[Random.Range(0, PoolOfProblems.Count)];
            if (ProblemIsBlocked(NewProblem))
            {
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
                if (BlockerEvents[i] == ActiveEvents[j])
                {
                    return true;
                }
            }
        }
        return false;
    }
}
