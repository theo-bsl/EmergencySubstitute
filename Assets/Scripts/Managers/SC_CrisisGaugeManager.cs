using UnityEngine;

public class SC_CrisisGaugeManager : MonoBehaviour
{
    public static SC_CrisisGaugeManager Instance;
    private float m_percentage;
    private float m_gaugeDecrease;
    private float m_waitTime;
    [SerializeField] private float m_timeToWaitBeforeDecreaseGauge;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void IncreaseGauge(float percentage)
    {
        m_percentage += percentage * Time.deltaTime;
        if (m_percentage >= 100)
        {
            SC_GameManager.Instance.Lose();
        }
    }

    public void DecreaseGauge(float percentage)
    {
        m_percentage -= percentage;
        m_percentage = m_percentage < 0 ? 0 : m_percentage;
    }

    public float GetCrisisPercentage()
    {
        return m_percentage;
    }

    private void Update()
    {
        if (SC_EventManager.Instance.NumberOfActiveCrisisEvent == 0)
        {
            m_waitTime += Time.deltaTime;

            if (m_waitTime >= m_timeToWaitBeforeDecreaseGauge)
            {
                DecreaseGauge(m_gaugeDecrease * Time.deltaTime);
            }
        }
        else
        {
            m_waitTime = 0;
        }
    }
}
