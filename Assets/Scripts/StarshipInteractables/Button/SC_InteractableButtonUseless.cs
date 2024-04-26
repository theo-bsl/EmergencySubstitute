using UnityEngine;

public class SC_InteractableButtonUseless : SC_InteractableButton
{
    private Transform m_transform;
    private bool m_isPressed = false;
    private Vector3 m_deltaPosition = new Vector3(0,0.005f,0);
    private void Awake()
    {
        m_transform = transform;
    }

    public override void OnButtonPressed()
    {
        if (!m_isPressed)
        {
            m_transform.position -= m_deltaPosition;
        }
        else
        {
            m_transform.position += m_deltaPosition;
        }
        m_isPressed = !m_isPressed;
    }
}
