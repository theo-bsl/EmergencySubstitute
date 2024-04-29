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

    public void Action(EventAction Action)
    {
        switch (Action)
        {
            case EventAction.LowCoolantLevel:
                LowCoolantLevelAction();
                break;
            case EventAction.ShipBodyBroke:
                ShipBodyBrokeAction();
                break;
            default: 
                break;
        }
    }

    private void LowCoolantLevelAction()
    {
        SC_StarshipManager.Instance.ChangeTemperature(1f / 2f);
        Debug.Log("LowCoolant !");
    }

    private void ShipBodyBrokeAction()
    {
        SC_StarshipManager.Instance.ChangeOxygen(1f/2f);
        SC_StarshipManager.Instance.ChangePressure(1f/2f);
        Debug.Log("Ship Body is Broken !");
    }
}
