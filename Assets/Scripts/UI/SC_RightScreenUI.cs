using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_RightScreenUI : MonoBehaviour
{
    [SerializeField] private Image m_gaugeCurrentContainer;
    [SerializeField] private Image m_gaugeCurrentFill;

    [SerializeField] private List<Sprite> m_gaugeFill;

    [SerializeField] private List<Sprite> m_gaugeContainer;

    [SerializeField] private Image m_crewContainer;
    private int m_nbCrewEvent = 0;
    private int m_maxOrange = 3;
    private int m_maxRed = 5;

    [SerializeField] private Image m_armorContainer;
    private int m_nbArmorEvent = 0;

    [SerializeField] private Image m_enginesContainer;
    private int m_nbEnginesEvent = 0;

    [SerializeField] private Image m_commandsContainer;
    private int m_nbCommandsEvent = 0;

    [SerializeField] private Image m_systemContainer;
    private int m_nbSystemEvents = 0;

    [SerializeField] private List<Sprite> m_containerColor;
    

    private SC_CrisisGaugeManager m_gaugeManager;
    private SC_EventManager m_eventManager;

    private void Start()
    {
        m_gaugeCurrentContainer.sprite = m_gaugeContainer[0];
        m_gaugeCurrentFill.sprite = m_gaugeFill[0];
        m_crewContainer.sprite = m_containerColor[0];
        m_armorContainer.sprite = m_containerColor[0];
        m_enginesContainer.sprite = m_containerColor[0];
        m_commandsContainer.sprite = m_containerColor[0];
        m_systemContainer.sprite = m_containerColor[0];
        m_gaugeManager = SC_CrisisGaugeManager.Instance;
        m_eventManager = SC_EventManager.Instance;

        m_eventManager.NewEvent.AddListener(NewEvent);
        m_eventManager.DeleteEvent.AddListener(DeleteEvent);
    }

    private void Update()
    {
        m_gaugeCurrentFill.fillAmount = m_gaugeManager.GetCrisisPercentage() / 100;
        if (m_gaugeManager.GetCrisisPercentage() >= 35 && m_gaugeManager.GetCrisisPercentage() < 65)
        {
            m_gaugeCurrentContainer.sprite = m_gaugeContainer[1];
            m_gaugeCurrentFill.sprite = m_gaugeFill[1];
        }
        else if (m_gaugeManager.GetCrisisPercentage() >= 65 && m_gaugeManager.GetCrisisPercentage() < 100)
        {
            m_gaugeCurrentContainer.sprite = m_gaugeContainer[2];
            m_gaugeCurrentFill.sprite = m_gaugeFill[2];
        }
    }

    private void NewEvent(SC_Event Event)
    {
        ChangeLogos(Event, 1);
    }

    private void DeleteEvent(SC_Event Event)
    {
        ChangeLogos(Event, -1);
    }

    private void ChangeLogos(SC_Event Event, int ind)
    {
        switch (Event.StarshipState)
        {
            case StarshipState.CrewHealth:
                m_nbCrewEvent += ind;
                if (m_nbCrewEvent < m_maxOrange)
                {
                    m_crewContainer.sprite = m_containerColor[0];
                }
                else if (m_nbCrewEvent > m_maxRed)
                {
                    m_crewContainer.sprite = m_containerColor[2];
                }
                else
                {
                    m_crewContainer.sprite = m_containerColor[1];
                }
                break;

            case StarshipState.Armor:
                m_nbArmorEvent += ind;
                if (m_nbArmorEvent < m_maxOrange)
                {
                    m_armorContainer.sprite = m_containerColor[0];
                }
                else if (m_nbArmorEvent > m_maxRed)
                {
                    m_armorContainer.sprite = m_containerColor[2];
                }
                else
                {
                    m_armorContainer.sprite = m_containerColor[1];
                }
                break;

            case StarshipState.Engines:
                m_nbEnginesEvent += ind;
                if (m_nbEnginesEvent < m_maxOrange)
                {
                    m_enginesContainer.sprite = m_containerColor[0];
                }
                else if (m_nbEnginesEvent > m_maxRed)
                {
                    m_enginesContainer.sprite = m_containerColor[2];
                }
                else
                {
                    m_enginesContainer.sprite = m_containerColor[1];
                }
                break;

            case StarshipState.Commands:
                m_nbCommandsEvent += ind;
                if (m_nbCommandsEvent < m_maxOrange)
                {
                    m_commandsContainer.sprite = m_containerColor[0];
                }
                else if (m_nbCommandsEvent > m_maxRed)
                {
                    m_commandsContainer.sprite = m_containerColor[2];
                }
                else
                {
                    m_commandsContainer.sprite = m_containerColor[1];
                }
                break;

            case StarshipState.System:
                m_nbSystemEvents += ind;
                if (m_nbSystemEvents < m_maxOrange)
                {
                    m_systemContainer.sprite = m_containerColor[0];
                }
                else if (m_nbSystemEvents > m_maxRed)
                {
                    m_systemContainer.sprite = m_containerColor[2];
                }
                else
                {
                    m_systemContainer.sprite = m_containerColor[1];
                }
                break;
        }
    }
}
