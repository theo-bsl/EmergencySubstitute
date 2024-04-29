using UnityEngine;

public abstract class SC_StarshipInteractable : MonoBehaviour
{
    protected bool m_hasBeenChosen;

    protected abstract void StarshipInteractableAction();
}
