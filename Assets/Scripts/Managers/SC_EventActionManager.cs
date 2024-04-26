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

    public void Action(EventAction Action, float value)
    {
        switch (Action)
        {
            case EventAction.LowCoolantLevel:
                LowCoolantLevelAction(value);
                break;
            case EventAction.ShipBodyBroke:
                ShipBodyBrokeAction(value);
                break;
            default: 
                break;
        }
    }

    private void LowCoolantLevelAction(float value)
    {
        SC_StarshipManager.Instance.ChangeTemperature(1f / 2f);
        Debug.Log("LowCoolant !");
    }

    private void ShipBodyBrokeAction(float value)
    {
        SC_StarshipManager.Instance.ChangeOxygen(1f/2f);
        SC_StarshipManager.Instance.ChangePressure(1f/2f);
        Debug.Log("Ship Body is Broken !");
    }
}
