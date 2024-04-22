using UnityEngine;

public class SC_CrisisGaugeManager : MonoBehaviour
{
    public static SC_CrisisGaugeManager Instance;
    private float m_percentage;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void IncreaseGauge(int percentage)
    {
        m_percentage += percentage;
        if (m_percentage >= 100)
        {
            SC_GameManager.Instance.Lose();
        }
    }
    public void DecreaseGauge(int percentage)
    {
        m_percentage += percentage;
    }
    public float GetCrisisPercentage()
    {
        return m_percentage;
    }
}
