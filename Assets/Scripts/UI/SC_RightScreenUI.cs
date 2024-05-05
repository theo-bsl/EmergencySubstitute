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
    
    private int m_crewCrisisEventCounter = 0;
    private int m_crewFatalEventCounter = 0;
    private int m_armorCrisisEventCounter = 0;
    private int m_armorFatalEventCounter = 0;
    private int m_enginesCrisisEventCounter = 0;
    private int m_enginesFatalEventCounter = 0;
    private int m_commandsCrisisEventCounter = 0;
    private int m_commandsFatalEventCounter = 0;
    private int m_systemCrisisEventCounter = 0;
    private int m_systemFatalEventCounter = 0;

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
        if (ind > 0)
        {
            switch (Event.StarshipState)
            {
                case StarshipState.CrewHealth:
                    if (IsEventCrisis(Event.EventAction))
                    {
                        if(m_crewFatalEventCounter == 0)
                        {
                            m_crewContainer.sprite = m_containerColor[1];
                        }
                        m_crewCrisisEventCounter++;
                    }
                    else
                    {
                        m_crewContainer.sprite = m_containerColor[2];
                        m_crewFatalEventCounter++;
                    }
                    break;

                case StarshipState.Armor:
                    if (IsEventCrisis(Event.EventAction))
                    {
                        if (m_armorFatalEventCounter == 0)
                        {
                            m_armorContainer.sprite = m_containerColor[1];
                        }
                        m_armorCrisisEventCounter++;
                    }
                    else
                    {
                        m_armorContainer.sprite = m_containerColor[2];
                        m_armorFatalEventCounter++;
                    }
                    break;

                case StarshipState.Engines:
                    if (IsEventCrisis(Event.EventAction))
                    {
                        if (m_enginesFatalEventCounter == 0)
                        {
                            m_enginesContainer.sprite = m_containerColor[1];
                        }
                        m_enginesCrisisEventCounter++;
}
                    else
                    {
                        m_enginesContainer.sprite = m_containerColor[2];
                        m_enginesFatalEventCounter++;
                    }
                    break;

                case StarshipState.Commands:
                    if (IsEventCrisis(Event.EventAction))
                    {
                        if (m_commandsFatalEventCounter == 0)
                        {
                            m_commandsContainer.sprite = m_containerColor[1];
                        }
                        m_commandsCrisisEventCounter++;
                    }
                    else
                    {
                        m_commandsContainer.sprite = m_containerColor[2];
                        m_commandsFatalEventCounter++;
                    }
                    break;

                case StarshipState.System:
                    if (IsEventCrisis(Event.EventAction))
                    {
                        if (m_systemFatalEventCounter == 0)
                        {
                            m_systemContainer.sprite = m_containerColor[1];
                        }
                        m_systemCrisisEventCounter++;
                    }
                    else
                    {
                        m_systemContainer.sprite = m_containerColor[2];
                        m_systemFatalEventCounter++;
                    }
                    break;
            }
        }
        else if (ind < 0)
        {
            switch (Event.StarshipState)
            {
                case StarshipState.CrewHealth:
                    if (IsEventCrisis(Event.EventAction))
                    {
                        m_crewCrisisEventCounter--;
                    }
                    else
                    {
                        m_crewFatalEventCounter--;
                    }
                    if(m_crewFatalEventCounter == 0)
                    {
                        if(m_crewCrisisEventCounter == 1)
                        {
                            m_crewContainer.sprite = m_containerColor[1];
                        }
                        else
                        {
                            m_crewContainer.sprite = m_containerColor[0];
                        }
                    }
                    break;

                case StarshipState.Armor:
                    if (IsEventCrisis(Event.EventAction))
                    {
                        m_armorCrisisEventCounter--;
                    }
                    else
                    {
                        m_armorFatalEventCounter--;
                    }
                    if (m_armorFatalEventCounter == 0)
                    {
                        if (m_armorCrisisEventCounter == 1)
                        {
                            m_armorContainer.sprite = m_containerColor[1];
                        }
                        else
                        {
                            m_armorContainer.sprite = m_containerColor[0];
                        }
                    }
                    break;

                case StarshipState.Engines:
                    if (IsEventCrisis(Event.EventAction))
                    {
                        m_enginesCrisisEventCounter--;
                    }
                    else
                    {
                        m_enginesFatalEventCounter--;
                    }
                    if (m_enginesFatalEventCounter == 0)
                    {
                        if (m_enginesCrisisEventCounter == 1)
                        {
                            m_enginesContainer.sprite = m_containerColor[1];
                        }
                        else
                        {
                            m_enginesContainer.sprite = m_containerColor[0];
                        }
                    }
                    break;

                case StarshipState.Commands:
                    if (IsEventCrisis(Event.EventAction))
                    {
                        m_commandsCrisisEventCounter--;
                    }
                    else
                    {
                        m_commandsFatalEventCounter--;
                    }
                    if (m_commandsFatalEventCounter == 0)
                    {
                        if (m_commandsCrisisEventCounter == 1)
                        {
                            m_commandsContainer.sprite = m_containerColor[1];
                        }
                        else
                        {
                            m_commandsContainer.sprite = m_containerColor[0];
                        }
                    }
                    break;

                case StarshipState.System:
                    if (IsEventCrisis(Event.EventAction))
                    {
                        m_systemCrisisEventCounter--;
                    }
                    else
                    {
                        m_systemFatalEventCounter--;
                    }
                    if (m_systemFatalEventCounter == 0)
                    {
                        if (m_systemCrisisEventCounter == 1)
                        {
                            m_systemContainer.sprite = m_containerColor[1];
                        }
                        else
                        {
                            m_systemContainer.sprite = m_containerColor[0];
                        }
                    }
                    break;
            }
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
