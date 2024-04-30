using UnityEngine;

public abstract class SC_InteractableButton : SC_StarshipInteractable
{
    private Transform m_transform;
    private bool m_isPressed = false;
    private Vector3 m_deltaPosition = new Vector3(0, 0.005f, 0);

    [SerializeField] private Texture2D m_mouseButtonHoverTexture;
    [SerializeField] private Texture2D m_mouseButtonClickTexture;
    [SerializeField] private Texture2D m_baseMouseTexture;
    private Vector2 m_mouseCenter = new Vector2(20,20);

    private void Awake()
    {
        m_transform = transform;
    }

    public void OnButtonPressed()
    {
        if (!m_isPressed)
        {
            m_transform.localPosition -= m_deltaPosition;
        }
        else
        {
            m_transform.localPosition += m_deltaPosition;
        }
        m_isPressed = !m_isPressed;
    }

    private void OnMouseOver()
    {
        if (!m_hasBeenChosen)
        {
            Cursor.SetCursor(m_mouseButtonHoverTexture, m_mouseCenter, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(m_mouseButtonClickTexture, m_mouseCenter, CursorMode.Auto);
        }
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(m_baseMouseTexture, m_mouseCenter, CursorMode.Auto);
    }
}
