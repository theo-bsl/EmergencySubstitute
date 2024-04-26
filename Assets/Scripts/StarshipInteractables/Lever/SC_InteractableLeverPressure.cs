using UnityEngine;

public class SC_InteractableLeverPressure : SC_InteractableLever
{
    protected override void StarshipInteractableAction()
    {
        SC_StarshipManager.Instance.ChangePressure(m_stateInd);
    }
}
