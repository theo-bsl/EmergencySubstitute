using UnityEngine;

public class SC_StarshipManager : MonoBehaviour
{
    public static SC_StarshipManager Instance;

    private float m_currentOxygen;
    private float m_criticalOxygen = 13f;
    private float m_lowOxygen = 17f;
    private float m_overOxygen = 80f;
    private bool m_isOverOxygenAlreadyActive = false;
    private bool m_isLowOxygenAlreadyActive = false;
    private bool m_isCriticalOxygenAlreadyActive = false;
    private int m_oxygenInd;

    private float m_currentSpeed;
    private float m_lowSpeed = 0f;
    private float m_overSpeed = 8500f;
    private bool m_isOverSpeedAlreadyActive = false;
    private bool m_isLowSpeedAlreadyActive = false;
    private int m_speedInd;

    private float m_currentPressure;
    private float m_overPressure = 1.6f;
    private float m_criticalPressure = 2.0f;
    private bool m_isOverPressureAlreadyActive = false;
    private bool m_isCriticalPressureAlreadyActive = false;
    private int m_pressureInd;

    private float m_currentTemperature;
    private float m_criticalUnderTemperature;
    private float m_underTemperature;
    private float m_overTemperature;
    private float m_criticalOverTemperature;
    private bool m_isCriticalUnderTemperatureAlreadyActive = false;
    private bool m_isUnderTemperatureAlreadyActive = false;
    private bool m_isOverTemperatureAlreadyActive = false;
    private bool m_isCriticalOverTemperatureAlreadyActive = false;
    private int m_temperatureInd;

    [SerializeField] private float m_distanceToDestination;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
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

    public void ChangeOxygen(float value)
    {
        m_currentOxygen += value;
        ManageOxygenEvent();
    }
    
    private void ManageOxygenEvent()
{
    //Catégorie oxygène trop élevé (>80%)
    if (m_currentOxygen > m_overOxygen && !m_isOverOxygenAlreadyActive)
    {
        m_isOverOxygenAlreadyActive = true;
        //Ajouter l'event "Oxygène trop élevé"
    }
    else if (m_currentOxygen < m_overOxygen && m_isOverOxygenAlreadyActive)
    {
        m_isOverOxygenAlreadyActive = false;
        //Retirer l'event "Oxygène trop élevé"
    }
    //Catégorie oxygène bas (<17%)
    else if (m_currentOxygen < m_lowOxygen && !m_isLowOxygenAlreadyActive)
    {
        m_isLowOxygenAlreadyActive = true;
        //Ajouter l'event "Manque d'oxygène"
    }
    else if (m_currentOxygen > m_lowOxygen && m_isLowOxygenAlreadyActive)
    {
        m_isLowOxygenAlreadyActive = false;
        //Retirer l'event "Manque d'oxygène"
    }
    //Catégorie oxygène critique (<13%)
    else if (m_currentOxygen < m_criticalOxygen && !m_isCriticalOxygenAlreadyActive)
    {
        m_isCriticalOxygenAlreadyActive = true;
        //Ajouter l'event "Manque d'oxygène critique"
    }
    else if (m_currentOxygen > m_criticalOxygen && m_isCriticalOxygenAlreadyActive)
    {
        m_isCriticalOxygenAlreadyActive = false;
        //Retirer l'event "Manque d'oxygène critique"
    }
}

    private void SpeedUpdate()
    {
        m_currentSpeed += m_speedInd;

        ManageSpeedEvent();
    }

    private void TemperatureUpdate()
    {
        m_currentTemperature += m_temperatureInd;

        ManageTemperatureEvent();
    }

    private void PressureUpdate()
    {
        m_currentPressure += m_pressureInd;

        ManagePressureEvent();
    }

    private void OxygenUpdate()
    {
        m_currentOxygen += m_oxygenInd;

        ManageOxygenEvent();
    }
    
    private void Travel()
{
    m_distanceToDestination -= m_currentSpeed * Time.deltaTime;
    ManageSpeedEvent();
}

private void ManageSpeedEvent()
{
    //Catégorie vitesse trop élevée (>8500)
    if (m_currentSpeed > m_overSpeed && !m_isOverSpeedAlreadyActive)
    {
        m_isOverSpeedAlreadyActive = true;
        //Ajouter l'event "Vitesse trop élevée"
    }
    else if (m_currentSpeed < m_overSpeed && m_isOverSpeedAlreadyActive)
    {
        m_isOverSpeedAlreadyActive = false;
        //Retirer l'event "Vitesse trop élevée"
    }
    //Catégorie Vitesse trop basse (=0)
    else if (m_currentSpeed < m_lowSpeed && !m_isLowSpeedAlreadyActive)
    {
        m_isLowSpeedAlreadyActive = true;
        //Ajouter l'event "Vitesse trop basse"
    }
    else if (m_currentSpeed > m_lowSpeed && m_isLowSpeedAlreadyActive)
    {
        m_isLowSpeedAlreadyActive = false;
        //Retirer l'event "Vitesse trop basse"
    }
}

    public void ChangePressure(float value)
{
    m_currentPressure += value;
    ManagePressureEvent();
}

private void ManagePressureEvent()
{
    //Catégorie surpression (>1.60 bar)
    if (m_currentPressure > m_overPressure && !m_isOverPressureAlreadyActive)
    {
        m_isOverPressureAlreadyActive = true;
        //Ajouter l'event "Surpression"
    }
    else if (m_currentPressure < m_overPressure && m_isOverPressureAlreadyActive)
    {
        m_isOverPressureAlreadyActive = false;
        //Retirer l'event "Surpression"
    }
    //Catégorie surpression critique (>2.0 bar)
    else if (m_currentPressure < m_criticalPressure && !m_isCriticalPressureAlreadyActive)
    {
        m_isCriticalPressureAlreadyActive = true;
        //Ajouter l'event "Surpression critique"
    }
    else if (m_currentPressure > m_criticalPressure && m_isCriticalPressureAlreadyActive)
    {
        m_isCriticalPressureAlreadyActive = false;
        //Retirer l'event "Surpression critique"
    }
}

    public void ChangeTemperature(float value)
{
    m_currentTemperature += value;
    ManageTemperatureEvent();
}

private void ManageTemperatureEvent()
{
    //Catégorie température critiquement trop basse (<-10°C)
    if (m_currentTemperature > m_criticalUnderTemperature && !m_isCriticalUnderTemperatureAlreadyActive)
    {
        m_isCriticalUnderTemperatureAlreadyActive = true;
        //Ajouter l'event "Température critiquement basse"
    }
    else if (m_currentTemperature < m_criticalUnderTemperature && m_isCriticalUnderTemperatureAlreadyActive)
    {
        m_isCriticalUnderTemperatureAlreadyActive = false;
        //Retirer l'event "Température critiquement basse"
    }
    //Catégorie température bas (<-5°C)
    else if (m_currentTemperature < m_underTemperature && !m_isUnderTemperatureAlreadyActive)
    {
        m_isUnderTemperatureAlreadyActive = true;
        //Ajouter l'event "Température basse"
    }
    else if (m_currentTemperature > m_underTemperature && m_isUnderTemperatureAlreadyActive)
    {
        m_isUnderTemperatureAlreadyActive = false;
        //Retirer l'event "Température basse"
    }
    //Catégorie température haute (>30°C)
    else if (m_currentTemperature > m_overTemperature && !m_isOverTemperatureAlreadyActive)
    {
        m_isOverTemperatureAlreadyActive = true;
        //Ajouter l'event "Température élevée"
    }
    else if (m_currentTemperature < m_overTemperature && m_isOverTemperatureAlreadyActive)
    {
        m_isOverTemperatureAlreadyActive = false;
        //Retirer l'event "Température élevée"
    }
    //Catégorie température critiquement haute (>50°C)
    else if (m_currentTemperature < m_criticalOverTemperature && !m_isCriticalOverTemperatureAlreadyActive)
    {
        m_isCriticalOverTemperatureAlreadyActive = true;
        //Ajouter l'event "Vitesse trop basse"
    }
    else if (m_currentTemperature > m_criticalOverTemperature && m_isCriticalOverTemperatureAlreadyActive)
    {
        m_isCriticalOverTemperatureAlreadyActive = false;
        //Retirer l'event "Vitesse trop basse"
    }
}
}
