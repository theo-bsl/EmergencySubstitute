public class SC_InteractableLeverHeater : SC_InteractableLever
{
    protected override void StarshipInteractableAction()
    {
        SC_StarshipManager.Instance.ChangeTemperature(m_stateInd);
    }
}