using UnityEngine;

public class SC_StarshipManager : MonoBehaviour
{
    public static SC_StarshipManager Instance;

    private float m_currentSpeed;
    private float m_minSpeed;
    private float m_maxSpeed;

    private float m_currentOxygen;
    private float m_minOxygen;
    private float m_maxOxygen;

    private float m_currentPressure;
    private float m_minPressure;
    private float m_maxPressure;

    private float m_currentTemperature;
    private float m_minTemperature;
    private float m_maxTemperature;

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
        if (m_currentTemperature + value <= m_minTemperature || m_currentTemperature + value >= m_maxTemperature)
        {
            //Invoquer events
        }
        else
        {
            m_currentTemperature += value;
        }
    }

    public void ChangeOxygen(float value)
    {
        if (m_currentOxygen + value <= m_minOxygen || m_currentOxygen + value >= m_maxOxygen)
        {
            //Invoquer events
        }
        else
        {
            m_currentOxygen += value;
        }
    }
    public void ChangePressure(float value)
    {
        if (m_currentPressure + value <= m_minPressure || m_currentPressure + value >= m_maxPressure)
        {
            //Invoquer events
        }
        else
        {
            m_currentPressure += value;
        }
    }

    public void ChangeSpeed(float value)
    {
        if (m_currentSpeed + value <= m_minSpeed || m_currentSpeed + value >= m_maxSpeed)
        {
            //Invoquer events
        }
        else
        {
            m_currentSpeed += value;
        }
    }
}
