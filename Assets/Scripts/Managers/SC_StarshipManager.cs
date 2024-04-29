using UnityEngine;

public class SC_StarshipManager : MonoBehaviour
{
    public static SC_StarshipManager Instance;

    private float m_currentSpeed = 0f;
    private float m_minSpeed = 0f;
    private float m_maxSpeed = 8500f;

    private float m_currentOxygen = 50f;
    private float m_minOxygen = 13f;
    private float m_maxOxygen = 80f;

    private float m_currentPressure = 1f;
    private float m_minPressure = 0f;
    private float m_maxPressure = 2.00f;

    private float m_currentTemperature = 20f;
    private float m_minTemperature = -5f;
    private float m_maxTemperature = 30f;

    [SerializeField] private float m_distanceToDestination;

    public float GetCurrentSpeed { get { return m_currentSpeed; } }
    public float GetMinSpeed { get { return m_minSpeed; } }
    public float GetMaxSpeed { get { return m_maxSpeed; } }
    public float GetCurrentOxygen { get { return m_currentOxygen; } }
    public float GetMinOxygen { get { return m_minOxygen; } }
    public float GetMaxOxygen { get { return m_maxOxygen; } }
    public float GetCurrentPressure { get { return m_currentPressure; } }
    public float GetMinPressure { get { return m_minPressure; } }
    public float GetMaxPressure { get { return m_maxPressure; } }
    public float GetCurrentTemperature { get { return m_currentTemperature; } }
    public float GetMinTemperature { get { return m_minTemperature; } }
    public float GetMaxTemperature { get { return m_maxTemperature; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ChangeTemperature(float value)
    {
        if (m_currentTemperature + value <= m_minTemperature)
        {
            m_currentTemperature = m_minTemperature;
        }
        else if (m_currentTemperature + value >= m_maxTemperature)
        {
            SC_GameManager.Instance.Lose();
        }
        else
        {
            m_currentTemperature += value;
        }
    }

    public void ChangeOxygen(float value)
    {
        if (m_currentOxygen + value <= m_minOxygen)
        {
            SC_GameManager.Instance.Lose();
        }
        else if (m_currentOxygen + value >= m_maxOxygen)
        {
            m_currentOxygen = m_maxOxygen;
        }
        else
        {
            m_currentOxygen += value;
        }
    }
    public void ChangePressure(float value)
    {
        if (m_currentPressure + value >= m_maxPressure)
        {
            SC_GameManager.Instance.Lose();
        }
        else if (m_currentPressure + value <= m_minPressure)
        {
            m_currentPressure = m_minPressure;
        }
        else 
        { 
            m_currentPressure += value; 
        }
    }
    private void Travel()
    {
        m_distanceToDestination -= m_currentSpeed * Time.deltaTime;
        if (m_distanceToDestination <= 0)
        {
            SC_GameManager.Instance.Win();
        }
    }

    private void Update()
    {
        Travel();
    }
}
