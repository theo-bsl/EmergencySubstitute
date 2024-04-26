using UnityEngine;

public class SC_StarshipManager : MonoBehaviour
{
    public static SC_StarshipManager Instance;

    private float m_currentSpeed;
    private float m_minSpeed;
    private float m_maxSpeed;
    private int m_speedInd;

    private float m_currentOxygen;
    private float m_minOxygen;
    private float m_maxOxygen;
    private int m_oxygenInd;

    private float m_currentPressure;
    private float m_minPressure;
    private float m_maxPressure;
    private int m_pressureInd;

    private float m_currentTemperature;
    private float m_minTemperature;
    private float m_maxTemperature;
    private int m_temperatureInd;

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

    private void Update()
    {
        SpeedUpdate();
        TemperatureUpdate();
        PressureUpdate();
        OxygenUpdate();
    }

    public void ChangeTemperature(int ind)
    {
        m_temperatureInd = ind;
    }

    public void ChangeOxygen(int ind)
    {
        m_oxygenInd = ind;
    }
    public void ChangePressure(int ind)
    {
        m_pressureInd = ind;
    }

    public void ChangeSpeed(int ind)
    {
        m_speedInd = ind;
    }

    private void SpeedUpdate()
    {
        if(m_speedInd > 0)
        {
            if (m_currentSpeed < m_maxSpeed)
            {
                m_currentSpeed++;
            }
        }
        else if (m_speedInd < 0)
        {
            if (m_currentSpeed > m_minSpeed)
            {
                m_currentSpeed--;
            }
        }
    }

    private void TemperatureUpdate()
    {
        if(m_temperatureInd > 0)
        {
            if (m_currentTemperature < m_maxTemperature)
            {
                m_currentTemperature++;
            }
        }
        else if(m_temperatureInd < 0)
        {
            if ( m_currentTemperature > m_minTemperature)
            {
                m_currentTemperature--;
            }
        }
    }

    private void PressureUpdate()
    {
        if(m_pressureInd > 0)
        {
            if (m_currentPressure < m_maxPressure)
            {
                m_currentPressure++;
            }
        }
        else if (m_pressureInd < 0)
        {
            if (m_currentPressure > m_minPressure)
            {
                m_currentPressure--;
            }
        }
    }

    private void OxygenUpdate()
    {
        if(m_oxygenInd > 0)
        {
            if (m_currentOxygen < m_maxOxygen)
            {
                m_currentOxygen++;
            }
        }
        else if (m_oxygenInd < 0)
        {
            if (m_currentOxygen > m_minOxygen)
            {
                m_currentOxygen--;
            }
        }
    }
}
