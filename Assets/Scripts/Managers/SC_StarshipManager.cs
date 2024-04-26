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

    private float m_currentSpeed;
    private float m_lowSpeed = 0f;
    private float m_overSpeed = 8500f;
    private bool m_isOverSpeedAlreadyActive = false;
    private bool m_isLowSpeedAlreadyActive = false;

    private float m_currentPressure;
    private float m_overPressure = 1.6f;
    private float m_criticalPressure = 2.0f;
    private bool m_isOverPressureAlreadyActive = false;
    private bool m_isCriticalPressureAlreadyActive = false;

    private float m_currentTemperature;
    private float m_criticalUnderTemperature;
    private float m_underTemperature;
    private float m_overTemperature;
    private float m_criticalOverTemperature;
    private bool m_isCriticalUnderTemperatureAlreadyActive = false;
    private bool m_isUnderTemperatureAlreadyActive = false;
    private bool m_isOverTemperatureAlreadyActive = false;
    private bool m_isCriticalOverTemperatureAlreadyActive = false;

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
        Travel();
    }

    public void ChangeOxygen(float value)
    {
        m_currentOxygen += value;

        //Cat�gorie oxyg�ne trop �lev� (>80%)
        if (m_currentOxygen > m_overOxygen && !m_isOverOxygenAlreadyActive)
        {
            m_isOverOxygenAlreadyActive = true;
            //Ajouter l'event "Oxyg�ne trop �lev�"
        }
        else if (m_currentOxygen < m_overOxygen && m_isOverOxygenAlreadyActive)
        {
            m_isOverOxygenAlreadyActive = false;
            //Retirer l'event "Oxyg�ne trop �lev�"
        }
        //Cat�gorie oxyg�ne bas (<17%)
        else if (m_currentOxygen < m_lowOxygen && !m_isLowOxygenAlreadyActive)
        {
            m_isLowOxygenAlreadyActive = true;
            //Ajouter l'event "Manque d'oxyg�ne"
        }
        else if (m_currentOxygen > m_lowOxygen && m_isLowOxygenAlreadyActive)
        {
            m_isLowOxygenAlreadyActive = false;
            //Retirer l'event "Manque d'oxyg�ne"
        }
        //Cat�gorie oxyg�ne critique (<13%)
        else if (m_currentOxygen < m_criticalOxygen && !m_isCriticalOxygenAlreadyActive)
        {
            m_isCriticalOxygenAlreadyActive = true;
            //Ajouter l'event "Manque d'oxyg�ne critique"
        }
        else if (m_currentOxygen > m_criticalOxygen && m_isCriticalOxygenAlreadyActive)
        {
            m_isCriticalOxygenAlreadyActive = false;
            //Retirer l'event "Manque d'oxyg�ne critique"
        }

    }

    private void Travel()
    {
        m_distanceToDestination -= m_currentSpeed * Time.deltaTime;

        //Cat�gorie vitesse trop �lev�e (>8500)
        if (m_currentSpeed > m_overSpeed && !m_isOverSpeedAlreadyActive)
        {
            m_isOverSpeedAlreadyActive = true;
            //Ajouter l'event "Vitesse trop �lev�e"
        }
        else if (m_currentSpeed < m_overSpeed && m_isOverSpeedAlreadyActive)
        {
            m_isOverSpeedAlreadyActive = false;
            //Retirer l'event "Vitesse trop �lev�e"
        }
        //Cat�gorie Vitesse trop basse (=0)
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

        //Cat�gorie surpression (>1.60 bar)
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
        //Cat�gorie surpression critique (>2.0 bar)
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
        //Cat�gorie temp�rature critiquement trop basse (<-10�C)
        if (m_currentTemperature > m_criticalUnderTemperature && !m_isCriticalUnderTemperatureAlreadyActive)
        {
            m_isCriticalUnderTemperatureAlreadyActive = true;
            //Ajouter l'event "Temp�rature critiquement basse"
        }
        else if (m_currentTemperature < m_criticalUnderTemperature && m_isCriticalUnderTemperatureAlreadyActive)
        {
            m_isCriticalUnderTemperatureAlreadyActive = false;
            //Retirer l'event "Temp�rature critiquement basse"
        }
        //Cat�gorie temp�rature bas (<-5�C)
        else if (m_currentTemperature < m_underTemperature && !m_isUnderTemperatureAlreadyActive)
        {
            m_isUnderTemperatureAlreadyActive = true;
            //Ajouter l'event "Temp�rature basse"
        }
        else if (m_currentTemperature > m_underTemperature && m_isUnderTemperatureAlreadyActive)
        {
            m_isUnderTemperatureAlreadyActive = false;
            //Retirer l'event "Temp�rature basse"
        }
        //Cat�gorie temp�rature haute (>30�C)
        else if (m_currentTemperature > m_overTemperature && !m_isOverTemperatureAlreadyActive)
        {
            m_isOverTemperatureAlreadyActive = true;
            //Ajouter l'event "Temp�rature �lev�e"
        }
        else if (m_currentTemperature < m_overTemperature && m_isOverTemperatureAlreadyActive)
        {
            m_isOverTemperatureAlreadyActive = false;
            //Retirer l'event "Temp�rature �lev�e"
        }
        //Cat�gorie temp�rature critiquement haute (>50�C)
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
