using UnityEngine;

public abstract class SC_InteractableLever : SC_StarshipInteractable
{
    private Vector3 m_dragDirection = Vector3.zero;
    [SerializeField] private Vector3 m_dragDirectionMask;

    private Quaternion m_deltaRotation;
    [SerializeField] private Vector3 m_deltaRotationMask;

    private Vector3 m_newRotation = Vector3.zero;

    protected int m_stateInd;

    private Transform m_transform;

    [SerializeField] private Texture2D m_mouseLeverHoverTexture;
    [SerializeField] private Texture2D m_mouseLeverDragTexture;
    [SerializeField] private Texture2D m_baseMouseTexture;

    private void Awake()
    {
        m_transform = transform;
    }

    public  void OnSelected() 
    { 
        m_hasBeenChosen = true;
    }
    public  void OnUnSelected() 
    {
        m_hasBeenChosen = false;
    }

    public void OnDragLever(Vector3 DragDirection) 
    {
        m_dragDirection.x = DragDirection.x * m_dragDirectionMask.x;
        m_dragDirection.y = DragDirection.y * m_dragDirectionMask.y;

        m_newRotation.x = m_dragDirection.x * m_deltaRotationMask.x + m_dragDirection.y * m_deltaRotationMask.x;
        m_newRotation.y = m_dragDirection.x * m_deltaRotationMask.y + m_dragDirection.y * m_deltaRotationMask.y;

        m_deltaRotation = Quaternion.Euler(m_newRotation);

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
        StarshipInteractableAction();
    }

    public bool GetIsSelected()
    {
        return m_hasBeenChosen;
    }

    private void OnMouseOver()
    {
        if (!m_hasBeenChosen)
        {
            Cursor.SetCursor(m_mouseLeverHoverTexture, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(m_mouseLeverDragTexture, Vector2.zero, CursorMode.Auto);
        }
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(m_baseMouseTexture, Vector2.zero, CursorMode.Auto);
    }
}
