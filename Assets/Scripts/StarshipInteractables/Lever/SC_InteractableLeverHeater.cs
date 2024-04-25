using UnityEngine;

public class SC_InteractableLeverHeater : SC_InteractableLever
{
    private Vector3 m_dragDirection = Vector3.zero;

    private Transform m_transform;

    private Transform m_baseTransform;

    private Quaternion m_deltaRotation;

    private float m_state;

    private void Awake()
    {
        m_transform = transform;
        m_baseTransform = m_transform;
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
            m_transform.rotation =  m_transform.rotation * m_deltaRotation;
            if (m_deltaRotation.x > 0)
            {
                m_state += m_deltaRotation.y;
            }
            else if (m_deltaRotation.x < 0)
            {
                m_state -= m_deltaRotation.y;
            }
        }
        if (m_state == 0)
        {
            m_transform.rotation = m_baseTransform.rotation;
        }
        else if (m_state > 0)
        {
            SC_StarshipManager.Instance.ChangeTemperature(m_dragDirection.y);
        }
        else if (m_state < 0)
        {
            SC_StarshipManager.Instance.ChangeTemperature(m_dragDirection.y);
        }
    }
}