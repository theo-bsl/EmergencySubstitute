using UnityEngine;
using UnityEngine.Events;

public class SC_StarshipManager : MonoBehaviour
{
    public static SC_StarshipManager Instance;

    private SC_EventManager m_eventManager;

    private float m_currentOxygen = 50f;
    private float m_criticalOxygen = 13f;
    private float m_lowOxygen = 17f;
    private float m_overOxygen = 80f;
    private bool m_isOverOxygenAlreadyActive = false;
    private bool m_isLowOxygenAlreadyActive = false;
    private bool m_isCriticalOxygenAlreadyActive = false;
    private int m_oxygenInd = 0;

    private float m_currentSpeed = 5000f;
    private float m_lowSpeed = 0f;
    private float m_overSpeed = 8500f;
    private bool m_isOverSpeedAlreadyActive = false;
    private bool m_isLowSpeedAlreadyActive = false;
    private int m_speedInd = 0;

    private float m_currentPressure = 1f;
    private float m_overPressure = 1.6f;
    private float m_criticalPressure = 2.0f;
    private bool m_isOverPressureAlreadyActive = false;
    private bool m_isCriticalPressureAlreadyActive = false;
    private int m_pressureInd = 0;

    private float m_currentTemperature = 20f;
    private float m_criticalUnderTemperature = -5f;
    private float m_underTemperature = 10f;
    private float m_overTemperature = 30f;
    private float m_criticalOverTemperature = 50f;
    private bool m_isCriticalUnderTemperatureAlreadyActive = false;
    private bool m_isUnderTemperatureAlreadyActive = false;
    private bool m_isOverTemperatureAlreadyActive = false;
    private bool m_isCriticalOverTemperatureAlreadyActive = false;
    private int m_temperatureInd = 0;

    [SerializeField] private SC_Event m_criticalUnderTemperatureEvent;
    [SerializeField] private SC_Event m_underTemperatureEvent;
    [SerializeField] private SC_Event m_overTemperatureEvent;
    [SerializeField] private SC_Event m_criticalOverTemperatureEvent;

    [SerializeField] private SC_Event m_overPressureEvent;
    [SerializeField] private SC_Event m_criticalPressureEvent;

    [SerializeField] private SC_Event m_lowSpeedEvent;
    [SerializeField] private SC_Event m_overSpeedEvent;

    [SerializeField] private SC_Event m_criticalOxygenEvent;
    [SerializeField] private SC_Event m_lowOxygenEvent;
    [SerializeField] private SC_Event m_overOxygenEvent;

    [SerializeField] private float m_distanceToDestination;

    private UnityEvent m_win = new UnityEvent();

    public UnityEvent Win { get { return m_win; } }

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
    }

    private void Update()
    {
        TemperatureUpdate();
        PressureUpdate();
        OxygenUpdate();
        SpeedUpdate();
        Travel();
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

    public void ChangeSpeed(float value)
    {
        m_currentSpeed = Mathf.Clamp(m_currentSpeed + value, 0f, Mathf.Infinity);
        ManageSpeedEvent();
    }

    public void ChangeOxygen(float value)
    {
        m_currentOxygen = Mathf.Clamp(m_currentOxygen + value, 0f, 100f);
        ManageOxygenEvent();
    }
    
    private void ManageOxygenEvent()
    {
        //Catégorie oxygène trop élevé (>80%)
        if (m_currentOxygen > m_overOxygen && !m_isOverOxygenAlreadyActive)
        {
            m_isOverOxygenAlreadyActive = true;
            m_eventManager.SpawnEvent(m_overOxygenEvent);
        }
        else if (m_currentOxygen < m_overOxygen && m_isOverOxygenAlreadyActive)
        {
            m_isOverOxygenAlreadyActive = false;
            m_eventManager.FindAndDestroyEvent(m_overOxygenEvent);
        }
        //Catégorie oxygène critique (<13%)
        else if (m_currentOxygen < m_criticalOxygen && !m_isCriticalOxygenAlreadyActive)
        {
            m_isCriticalOxygenAlreadyActive = true;
            m_eventManager.SpawnEvent(m_criticalOxygenEvent);
        }
        else if (m_currentOxygen > m_criticalOxygen && m_isCriticalOxygenAlreadyActive)
        {
            m_isCriticalOxygenAlreadyActive = false;
            m_eventManager.FindAndDestroyEvent(m_criticalOxygenEvent);
        }
        //Catégorie oxygène bas (<17%)
        else if (m_currentOxygen < m_lowOxygen && !m_isLowOxygenAlreadyActive)
        {
            m_isLowOxygenAlreadyActive = true;
            m_eventManager.SpawnEvent(m_lowOxygenEvent);
        }
        else if (m_currentOxygen > m_lowOxygen && m_isLowOxygenAlreadyActive)
        {
            m_isLowOxygenAlreadyActive = false;
            m_eventManager.FindAndDestroyEvent(m_lowOxygenEvent);
        }
    }

    private void SpeedUpdate()
    {
        m_currentSpeed = Mathf.Clamp(m_currentSpeed + (m_speedInd * Time.deltaTime), 0f, Mathf.Infinity);

        ManageSpeedEvent();
    }

    private void TemperatureUpdate()
    {
        m_currentTemperature = Mathf.Clamp(m_currentTemperature + (m_temperatureInd * Time.deltaTime), -273.15f, Mathf.Infinity);

        ManageTemperatureEvent();
    }

    private void PressureUpdate()
    {
        m_currentPressure = Mathf.Clamp(m_currentPressure + (m_pressureInd * Time.deltaTime), 0f, Mathf.Infinity);

        ManagePressureEvent();
    }

    private void OxygenUpdate()
    {
        m_currentOxygen = Mathf.Clamp(m_currentOxygen + (m_oxygenInd * Time.deltaTime), 0f, Mathf.Infinity);

        ManageOxygenEvent();
    }
    
    private void Travel()
    {
        m_distanceToDestination -= m_currentSpeed * Time.deltaTime;
        if (m_distanceToDestination <= 0f) 
        {
            m_win.Invoke();
        }
        ManageSpeedEvent();
    }

    private void ManageSpeedEvent()
    {
        //Catégorie vitesse trop élevée (>8500)
        if (m_currentSpeed > m_overSpeed && !m_isOverSpeedAlreadyActive)
        {
            m_isOverSpeedAlreadyActive = true;
            m_eventManager.SpawnEvent(m_overSpeedEvent);
        }
        else if (m_currentSpeed < m_overSpeed && m_isOverSpeedAlreadyActive)
        {
            m_isOverSpeedAlreadyActive = false;
            m_eventManager.FindAndDestroyEvent(m_overSpeedEvent);
        }
        //Catégorie Vitesse trop basse (=0)
        else if (m_currentSpeed < m_lowSpeed && !m_isLowSpeedAlreadyActive)
        {
            m_isLowSpeedAlreadyActive = true;
            m_eventManager.SpawnEvent(m_lowSpeedEvent);
        }
        else if (m_currentSpeed > m_lowSpeed && m_isLowSpeedAlreadyActive)
        {
            m_isLowSpeedAlreadyActive = false;
            m_eventManager.FindAndDestroyEvent(m_lowSpeedEvent);
        }
    }

    public void ChangePressure(float value)
    {
        m_currentPressure = Mathf.Clamp(m_currentPressure + value, 0f, Mathf.Infinity);
        ManagePressureEvent();
    }

    private void ManagePressureEvent()
    {
        //Catégorie surpression critique (>2.0 bar)
        if (m_currentPressure > m_criticalPressure && !m_isCriticalPressureAlreadyActive)
        {
            m_isCriticalPressureAlreadyActive = true;
            m_eventManager.SpawnEvent(m_criticalPressureEvent);
        }
        else if (m_currentPressure < m_criticalPressure && m_isCriticalPressureAlreadyActive)
        {
            m_isCriticalPressureAlreadyActive = false;
            m_eventManager.FindAndDestroyEvent(m_criticalPressureEvent);
        }
        //Catégorie surpression (>1.60 bar)
        else if (m_currentPressure > m_overPressure && !m_isOverPressureAlreadyActive)
        {
            m_isOverPressureAlreadyActive = true;
            m_eventManager.SpawnEvent(m_overPressureEvent);
        }
        else if (m_currentPressure < m_overPressure && m_isOverPressureAlreadyActive)
        {
            m_isOverPressureAlreadyActive = false;
            m_eventManager.FindAndDestroyEvent(m_overPressureEvent);
        }
    }

    public void ChangeTemperature(float value)
    {
        m_currentTemperature = Mathf.Clamp(m_currentTemperature + value, -273.15f, Mathf.Infinity);
        ManageTemperatureEvent();
    }

    private void ManageTemperatureEvent()
    {
        //Catégorie température critiquement trop basse (<-10°C)
        if (m_currentTemperature < m_criticalUnderTemperature && !m_isCriticalUnderTemperatureAlreadyActive)
        {
            m_isCriticalUnderTemperatureAlreadyActive = true;
            m_eventManager.SpawnEvent(m_criticalUnderTemperatureEvent);
        }
        else if (m_currentTemperature > m_criticalUnderTemperature && m_isCriticalUnderTemperatureAlreadyActive)
        {
            m_isCriticalUnderTemperatureAlreadyActive = false;
            m_eventManager.FindAndDestroyEvent(m_criticalUnderTemperatureEvent);
        }
        //Catégorie température bas (<-5°C)
        else if (m_currentTemperature < m_underTemperature && !m_isUnderTemperatureAlreadyActive)
        {
            m_isUnderTemperatureAlreadyActive = true;
            m_eventManager.SpawnEvent(m_underTemperatureEvent);
        }
        else if (m_currentTemperature > m_underTemperature && m_isUnderTemperatureAlreadyActive)
        {
            m_isUnderTemperatureAlreadyActive = false;
            m_eventManager.FindAndDestroyEvent(m_underTemperatureEvent);
        }
        //Catégorie température critiquement haute (>50°C)
        else if (m_currentTemperature > m_criticalOverTemperature && !m_isCriticalOverTemperatureAlreadyActive)
        {
            m_isCriticalOverTemperatureAlreadyActive = true;
            m_eventManager.SpawnEvent(m_criticalOverTemperatureEvent);
        }
        else if (m_currentTemperature < m_criticalOverTemperature && m_isCriticalOverTemperatureAlreadyActive)
        {
            m_isCriticalOverTemperatureAlreadyActive = false;
            m_eventManager.FindAndDestroyEvent(m_criticalOverTemperatureEvent);
        }
        //Catégorie température haute (>30°C)
        else if (m_currentTemperature > m_overTemperature && !m_isOverTemperatureAlreadyActive)
        {
            m_isOverTemperatureAlreadyActive = true;
            m_eventManager.SpawnEvent(m_overTemperatureEvent);
        }
        else if (m_currentTemperature < m_overTemperature && m_isOverTemperatureAlreadyActive)
        {
            m_isOverTemperatureAlreadyActive = false;
            m_eventManager.FindAndDestroyEvent(m_overTemperatureEvent);
        }
    }

    public float GetTemperature() { return m_currentTemperature; }
    public float GetPressure() {  return m_currentPressure; }
    public float GetOxygen() { return m_currentOxygen; }
    public float GetSpeed() {  return m_currentSpeed; }
}
