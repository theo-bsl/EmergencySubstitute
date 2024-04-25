using UnityEngine;

public class SC_InteractableLeverThrottle : SC_InteractableLever
{
    private Vector3 m_dragDirection = Vector3.zero;

    private Transform m_transform;

    private Quaternion m_deltaRotation;

    private void Awake()
    {
        m_transform = transform;
    }

    public override void OnSelected()
    {
        m_hasBeenChosen = true;
    }

    public override void OnUnSelected()
    {
        m_hasBeenChosen = false;
    }

    public override void OnDragLever(Vector3 DragDist)
    {
        if (m_hasBeenChosen)
        {
            m_dragDirection.y = DragDist.y;
            m_deltaRotation = Quaternion.Euler(m_dragDirection.y, 0, 0);
            m_transform.rotation = m_transform.rotation * m_deltaRotation;
            SC_StarshipManager.Instance.ChangeSpeed(m_dragDirection.y);
        }
    }
}
