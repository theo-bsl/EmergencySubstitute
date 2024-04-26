using UnityEngine;

public class SC_InteractableLeverOxygen : SC_InteractableLever
{
    protected override void StarshipInteractableAction()
    {
        SC_StarshipManager.Instance.ChangeOxygen(m_stateInd);
    }
}
