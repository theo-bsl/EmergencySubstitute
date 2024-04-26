using UnityEngine;

public class SC_InteractableLeverPressure : SC_InteractableLever
{
    private Vector3 m_dragDirection = Vector3.zero;

    private Transform m_transform;

    private Quaternion m_deltaRotation;

    private int m_stateInd;

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
            m_dragDirection.x = DragDist.x;
            m_deltaRotation = Quaternion.Euler(0, m_dragDirection.x, 0);
            m_transform.rotation = m_transform.rotation * m_deltaRotation;
            if (m_transform.eulerAngles.y >= 90 && m_transform.eulerAngles.y <= 180)
            {
                m_stateInd = 1;
            }
            else if (m_transform.eulerAngles.y <= 270 && m_transform.eulerAngles.y > 180)
            {
                m_stateInd = -1;
            }
            else
            {
                m_stateInd = 0;
            }
        }
        SC_StarshipManager.Instance.ChangePressure(m_stateInd);
    }
}
