using UnityEngine;

public class SC_StarshipController : MonoBehaviour
{
    public static SC_StarshipController Instance;
    [SerializeField] private SC_InteractableLeverThrottle m_accelerator;
    [SerializeField] private GameObject m_orientationL;
    [SerializeField] private GameObject m_orientationR;
    [SerializeField] private GameObject m_circuitBreaker;
    [SerializeField] private SC_InteractableLeverHeater m_heater;
    [SerializeField] private GameObject m_radio;
    [SerializeField] private GameObject m_joystick;
    [SerializeField] private GameObject m_lights;
    [SerializeField] private SC_InteractableLeverFrequency m_radioFrequency;
    [SerializeField] private GameObject m_microphone;
    [SerializeField] private GameObject m_ADF;
    private Vector3 m_dragDist;
    private bool m_dragging;

    private Camera m_camera;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        m_camera = Camera.main;
        m_dragDist = Vector3.zero;
        m_dragging = false;
    }

    private void Update()
    {
        CheckIsDragging();
    }

    private void CheckIsDragging()
    {
        if (m_dragging)
        {
            if (m_accelerator.GetIsSelected())
            {
                m_accelerator.OnDragLever(m_dragDist);
            }
            if (m_heater.GetIsSelected())
            {
                m_heater.OnDragLever(m_dragDist);
            }
            if (m_radioFrequency.GetIsSelected())
            {
                m_radioFrequency.OnDragLever(m_dragDist);
            }
        }
    }

    public bool CheckForInteractable(Vector3 MousePos)
    {
        Vector3 dir = MousePos - m_camera.transform.position;
        Physics.Raycast(m_camera.transform.position, dir, out RaycastHit hit, Mathf.Infinity);
        Debug.DrawRay(m_camera.transform.position, dir * 1000, Color.green, 10);

        if (hit.collider == m_accelerator.GetComponent<Collider>())
        {
            UseAccelerator();
        }
        else if (hit.collider == m_orientationL.GetComponent<Collider>())
        {
            OrientateLeft();
        }
        else if (hit.collider == m_orientationR.GetComponent<Collider>())
        {
            OrientateRight();
        }
        else if (hit.collider == m_circuitBreaker.GetComponent<Collider>())
        {
            Breakcircuit();
        }
        else if (hit.collider == m_heater.GetComponent<Collider>())
        {
            temperature();
        }
        else if (hit.collider == m_radio.GetComponent<Collider>())
        {
            SwitchRadio();
        }
        else if (hit.collider == m_joystick.GetComponent<Collider>())
        {
            UseJoystick();
        }
        else if (hit.collider == m_lights.GetComponent<Collider>())
        {
            SwitchLights();
        }
        else if (hit.collider == m_radioFrequency.GetComponent<Collider>())
        {
            ChangeFrequency();
        }
        else if (hit.collider == m_microphone.GetComponent<Collider>())
        {
            MicOnOff();
        }
        else if (hit.collider == m_ADF.GetComponent<Collider>())
        {
            ADFOnOff();
        }
        return Physics.Raycast(m_camera.transform.position, dir, Mathf.Infinity);
    }

    private void UseAccelerator()
    {
        m_accelerator.OnSelected();
    }

    private void OrientateLeft()
    {
        Debug.Log("orientation Left");
    }

    private void OrientateRight()
    {
        Debug.Log("orientation Right");
    }

    private void Breakcircuit()
    {
        Debug.Log("Broke circuit");
    }
    private void temperature()
    {
        m_heater.OnSelected();
    }
    private void SwitchRadio()
    {
        Debug.Log("radio");
    }
    private void UseJoystick()
    {
        Debug.Log("joystick");
    }
    private void SwitchLights()
    {
        Debug.Log("lights");
    }
    private void ChangeFrequency()
    {
        m_radioFrequency.OnSelected();
    }
    private void MicOnOff()
    {
        Debug.Log("Mic");
    }
    private void ADFOnOff()
    {
        Debug.Log("adf");
    }
    public void SetDragDist(Vector3 value)
    {
        m_dragDist = value;
    }
    public void SetIsDragging(bool value)
    {
        if (!value)
        {
            m_accelerator.OnUnSelected();
            m_heater.OnUnSelected();
            m_radioFrequency.OnUnSelected();
        }
        m_dragging = value;
    }
}
