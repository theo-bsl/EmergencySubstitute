using UnityEngine;

public abstract class SC_InteractableLever : SC_StarshipInteractable
{
    private Vector3 m_dragDirection = Vector3.zero;
    [SerializeField] private Vector3 m_dragDirectionMask;

    private Vector3 m_deltaRotation;
    [SerializeField] private Vector3 m_deltaRotationMask;

    [SerializeField] private float m_minRotationLimit;
    [SerializeField] private float m_maxRotationLimit;

    protected int m_stateInd;

    private Transform m_transform;

    [SerializeField] private Texture2D m_mouseLeverHoverTexture;
    [SerializeField] private Texture2D m_mouseLeverDragTexture;
    [SerializeField] private Texture2D m_baseMouseTexture;
    private Vector2 m_mouseCenter = new Vector2(24, 5);

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

        m_deltaRotation.x = m_dragDirection.x * m_deltaRotationMask.x + m_dragDirection.y * m_deltaRotationMask.x;
        m_deltaRotation.y = m_dragDirection.x * m_deltaRotationMask.y + m_dragDirection.y * m_deltaRotationMask.y;

        if (CheckForNewRotation())
        {
            m_transform.rotation *= Quaternion.Euler(m_deltaRotation);

            ManageInd();
        }

        StarshipInteractableAction();
    }

    private bool CheckForNewRotation()
    {
        //Debug.Log("localEulerAngles = " + m_transform.localEulerAngles);

        //float newRotation = (MultiplyVector(m_transform.localEulerAngles, m_deltaRotationMask) + m_deltaRotation).magnitude;
        Vector3 newRotation = m_transform.localEulerAngles + m_deltaRotation;

        float interestingAngles = newRotation.x * m_deltaRotationMask.x + newRotation.y * m_deltaRotationMask.y + newRotation.z * m_deltaRotationMask.z;

        return interestingAngles > m_minRotationLimit && interestingAngles < m_maxRotationLimit;
    }

    private void ManageInd()
    {
        if (MultiplyVector(m_transform.localEulerAngles, m_deltaRotationMask).magnitude > 0)
        {

        }

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

    private Vector3 MultiplyVector(Vector3 v1, Vector3 v2)
    {
        return new Vector3(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
    }

    public bool GetIsSelected()
    {
        return m_hasBeenChosen;
    }

    private void OnMouseOver()
    {
        if (!m_hasBeenChosen)
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }

    private void OnMouseExit()
    {
        if (!m_hasBeenChosen)
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);

        //Cursor.SetCursor(m_baseMouseTexture, m_mouseCenter, CursorMode.Auto);
    }
}
