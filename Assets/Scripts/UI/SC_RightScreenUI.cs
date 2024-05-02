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

    [SerializeField] private Image m_armorContainer;

    [SerializeField] private Image m_enginesContainer;

    [SerializeField] private Image m_commandsContainer;

    [SerializeField] private Image m_systemContainer;

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
                if (IsEventCrisis(Event.EventAction))
                {
                    m_crewContainer.sprite = m_containerColor[1];
                }
                else
                {
                    m_crewContainer.sprite = m_containerColor[2];
                }
                break;

            case StarshipState.Armor:
                if (IsEventCrisis(Event.EventAction))
                {
                    m_armorContainer.sprite = m_containerColor[1];
                }
                else
                {
                    m_armorContainer.sprite = m_containerColor[2];
                }
                break;

            case StarshipState.Engines:
                if (IsEventCrisis(Event.EventAction))
                {
                    m_enginesContainer.sprite = m_containerColor[1];
                }
                else
                {
                    m_enginesContainer.sprite = m_containerColor[2];
                }
                break;

            case StarshipState.Commands:
                if (IsEventCrisis(Event.EventAction))
                {
                    m_commandsContainer.sprite = m_containerColor[1];
                }
                else
                {
                    m_commandsContainer.sprite = m_containerColor[2];
                }
                break;

            case StarshipState.System:
                if (IsEventCrisis(Event.EventAction))
                {
                    m_systemContainer.sprite = m_containerColor[1];
                }
                else
                {
                    m_systemContainer.sprite = m_containerColor[2];
                }
                break;
        }
    }

    private bool IsEventCrisis(List<EventAction> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].EventActionType == EventActionType.IncreaseGauge)
            {
                return true;
            }
        }
        return false;
    }
}
