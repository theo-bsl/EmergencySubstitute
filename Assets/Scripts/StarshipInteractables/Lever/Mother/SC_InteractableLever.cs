using UnityEngine;

public abstract class SC_InteractableLever : SC_StarshipInteractable
{
    private Vector3 m_dragDirection = Vector3.zero;
    [SerializeField] private Vector3 m_dragDirectionMask;

    private Vector3 m_deltaRotation;
    [SerializeField] private Vector3 m_deltaRotationMask;

    [SerializeField] private float m_minRotationLimit;
    [SerializeField] private float m_maxRotationLimit;

    [SerializeField] protected int m_stateInd;

    private Transform m_transform;

    [SerializeField] private Texture2D m_mouseLeverHoverTexture;
    [SerializeField] private Texture2D m_mouseLeverDragTexture;
    [SerializeField] private Texture2D m_baseMouseTexture;
    private Vector2 m_mouseCenter = new Vector2(24, 5);

    private void Awake()
    {
        m_transform = transform;
    }

    private void Start()
    {
        ManageInd();
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
        Vector3 newRotation = m_transform.localEulerAngles + m_deltaRotation;

        float interestingAngles = newRotation.x * m_deltaRotationMask.x + newRotation.y * m_deltaRotationMask.y + newRotation.z * m_deltaRotationMask.z;
        //interestingAngles = interestingAngles < 0 ? 360 + interestingAngles : interestingAngles;

        if (m_minRotationLimit > m_maxRotationLimit)
        {
            if (interestingAngles < 0)
            {
                return interestingAngles + 360 > m_minRotationLimit && interestingAngles < m_maxRotationLimit;
            }
            else 
            {
                if (interestingAngles < m_maxRotationLimit)
                {
                    return interestingAngles > m_minRotationLimit - 360;
                }
                else
                    return interestingAngles > m_minRotationLimit;
            }
        }

        return interestingAngles > m_minRotationLimit && interestingAngles < m_maxRotationLimit;
    }

    private void ManageInd()
    {
        float maxAngle = m_maxRotationLimit;
        float minAngle = m_minRotationLimit;
        float currentAngle = m_transform.localEulerAngles.x * m_deltaRotationMask.x + m_transform.localEulerAngles.y * m_deltaRotationMask.y + m_transform.localEulerAngles.z * m_deltaRotationMask.z;

        if (minAngle > maxAngle)
        {
            maxAngle += 360 - minAngle;
            currentAngle += 360 - minAngle;
            currentAngle -= currentAngle >= 360 ? 360 : 0;
            minAngle = 0;
        }

        float operatingAngle = maxAngle - minAngle;

        if (currentAngle < operatingAngle / 3)
        {
            m_stateInd = -1;
        }
        else if (currentAngle < operatingAngle / 3 * 2)
        {
            m_stateInd = 0;
        }
        else
        {
            m_stateInd = 1;
        }

        /*float interestingAngles = m_transform.localEulerAngles.x * m_deltaRotationMask.x + m_transform.localEulerAngles.y * m_deltaRotationMask.y + m_transform.localEulerAngles.z * m_deltaRotationMask.z;
        float operatingAngle = Mathf.Abs(m_maxRotationLimit - m_minRotationLimit);

        if (m_minRotationLimit > m_maxRotationLimit)
        {

        }
        else
        {
            if (interestingAngles < operatingAngle / 3)
            {
                m_stateInd = -1;
            }
            else if (interestingAngles < operatingAngle / 3 * 2)
            {
                m_stateInd = 0;
            }
            else
            {
                m_stateInd = 1;
            }
        }*/
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
