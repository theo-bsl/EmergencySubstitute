public class SC_InteractableLeverThrottle : SC_InteractableLever
{
    protected override void StarshipInteractableAction()
    {
        SC_StarshipManager.Instance.ChangeSpeed(m_stateInd);
    }
}
