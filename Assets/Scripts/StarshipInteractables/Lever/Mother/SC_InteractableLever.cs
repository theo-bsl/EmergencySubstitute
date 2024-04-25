using UnityEngine;
public class SC_InteractableLever : SC_StarshipInteractable
{
    public virtual void OnSelected() { }
    public virtual void OnUnSelected() { }
    public virtual void OnDragLever(Vector3 DragDist) { }

    public bool GetIsSelected()
    {
        return m_hasBeenChosen;
    }
}
