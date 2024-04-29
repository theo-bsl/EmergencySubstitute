using UnityEngine;

public class SC_EventActionManager : MonoBehaviour
{
    public static SC_EventActionManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void Action(EventAction eventAction)
    {
        switch (eventAction.EventActionType)
        {
            case EventActionType.ChangeTemperature:
                SC_StarshipManager.Instance.ChangeTemperature(eventAction.EventActionValue * Time.deltaTime);
                break;
            case EventActionType.ChangeOxygen:
                SC_StarshipManager.Instance.ChangeOxygen(eventAction.EventActionValue * Time.deltaTime);
                break;
            case EventActionType.ChangePressure:
                SC_StarshipManager.Instance.ChangePressure(eventAction.EventActionValue * Time.deltaTime);
                break;
            case EventActionType.ChangeSpeed:
                SC_StarshipManager.Instance.ChangeSpeed(eventAction.EventActionValue * Time.deltaTime);
                break;
            case EventActionType.IncreaseGauge:
                SC_CrisisGaugeManager.Instance.IncreaseGauge(eventAction.EventActionValue);
                break;
            default: 
                break;
        }
    }
}
