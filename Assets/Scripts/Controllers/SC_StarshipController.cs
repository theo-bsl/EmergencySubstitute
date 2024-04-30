using UnityEngine;

public class SC_StarshipController : MonoBehaviour
{
    public static SC_StarshipController Instance;
    [SerializeField] private SC_InteractableLeverThrottle m_accelerator;
    [SerializeField] private SC_InteractableLeverHeater m_heater;
    [SerializeField] private SC_InteractableLeverOxygen m_oxygen;
    [SerializeField] private SC_InteractableLeverPressure m_pressure;
    [SerializeField] private SC_InteractableLeverUseless m_lever;
    [SerializeField] private SC_InteractableLeverUseless m_lever2;
    [SerializeField] private SC_InteractableButtonUseless m_buttonUp1;
    [SerializeField] private SC_InteractableButtonUseless m_buttonUp2;
    [SerializeField] private SC_InteractableButtonUseless m_buttonA1;
    [SerializeField] private SC_InteractableButtonUseless m_buttonA2;
    [SerializeField] private SC_InteractableButtonUseless m_buttonA3;
    [SerializeField] private SC_InteractableButtonUseless m_buttonB1;
    [SerializeField] private SC_InteractableButtonUseless m_buttonB2;
    [SerializeField] private SC_InteractableButtonUseless m_buttonB3;
    [SerializeField] private SC_InteractableButtonUseless m_buttonC1;
    [SerializeField] private SC_InteractableButtonUseless m_buttonC2;
    [SerializeField] private SC_InteractableButtonUseless m_buttonC3;
    [SerializeField] private SC_InteractableButtonUseless m_buttonD1;
    [SerializeField] private SC_InteractableButtonUseless m_buttonD2;
    [SerializeField] private SC_InteractableButtonUseless m_buttonD3;
    [SerializeField] private SC_InteractableButtonUseless m_sideButton1;
    [SerializeField] private SC_InteractableButtonUseless m_sideButton2;
    [SerializeField] private SC_InteractableButtonUseless m_sideButton3;
    [SerializeField] private SC_InteractableButtonUseless m_sideButton4;
    [SerializeField] private SC_InteractableButtonUseless m_sideButton5;
    [SerializeField] private SC_InteractableButtonUseless m_sideButton6;
    [SerializeField] private SC_InteractableButtonUseless m_sideButton7;
    [SerializeField] private SC_InteractableLeverSwitch m_switch1;
    [SerializeField] private SC_InteractableLeverSwitch m_switch2;
    [SerializeField] private SC_InteractableLeverSwitch m_switch3;
    [SerializeField] private SC_InteractableLeverSwitch m_switch4;
    [SerializeField] private SC_InteractableLeverSwitch m_switch5;
    [SerializeField] private GameObject m_screen;
    [SerializeField] private Animator m_animator;
    private bool m_isZooming = false;
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
            if (m_oxygen.GetIsSelected())
            {
                m_oxygen.OnDragLever(m_dragDist);
            }
            if (m_pressure.GetIsSelected())
            {
                m_pressure.OnDragLever(m_dragDist);
            }
            if (m_lever.GetIsSelected())
            {
                m_lever.OnDragLever(m_dragDist);
            }
            if (m_lever2.GetIsSelected())
            {
                m_lever2.OnDragLever(m_dragDist);
            }
            if (m_switch1.GetIsSelected())
            {
                m_switch1.OnDragLever(m_dragDist);
            }
            if (m_switch2.GetIsSelected())
            {
                m_switch2.OnDragLever(m_dragDist);
            }
            if (m_switch3.GetIsSelected())
            {
                m_switch3.OnDragLever(m_dragDist);
            }
            if (m_switch4.GetIsSelected())
            {
                m_switch4.OnDragLever(m_dragDist);
            }
            if (m_switch5.GetIsSelected())
            {
                m_switch5.OnDragLever(m_dragDist);
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
        else if (hit.collider == m_heater.GetComponent<Collider>())
        {
            temperature();
        }
        else if (hit.collider == m_oxygen.GetComponent<Collider>())
        {
            ChangeOxygen();
        }
        else if (hit.collider == m_pressure.GetComponent<Collider>())
        {
            ChangePressure();
        }
        else if (hit.collider == m_lever.GetComponent<Collider>())
        {
            PullLever();
        }
        else if (hit.collider == m_lever2.GetComponent<Collider>())
        {
            PullLever2();
        }
        else if (hit.collider == m_switch1.GetComponent<Collider>())
        {
            PullSwitch1();
        }
        else if (hit.collider == m_switch2.GetComponent<Collider>())
        {
            PullSwitch2();
        }
        else if (hit.collider == m_switch3.GetComponent<Collider>())
        {
            PullSwitch3();
        }
        else if (hit.collider == m_switch4.GetComponent<Collider>())
        {
            PullSwitch4();
        }
        else if (hit.collider == m_switch5.GetComponent<Collider>())
        {
            PullSwitch5();
        }
        else if (hit.collider == m_buttonUp2.GetComponent<Collider>())
        {
            m_buttonUp2.OnButtonPressed();
        }
        else if (hit.collider == m_buttonUp1.GetComponent<Collider>())
        {
            m_buttonUp1.OnButtonPressed();
        }
        else if (hit.collider == m_buttonA1.GetComponent<Collider>())
        {
            m_buttonA1.OnButtonPressed();
        }
        else if (hit.collider == m_buttonA2.GetComponent<Collider>())
        {
            m_buttonA2.OnButtonPressed();
        }
        else if (hit.collider == m_buttonA3.GetComponent<Collider>())
        {
            m_buttonA3.OnButtonPressed();
        }
        else if (hit.collider == m_buttonB1.GetComponent<Collider>())
        {
            m_buttonB1.OnButtonPressed();
        }
        else if (hit.collider == m_buttonB2.GetComponent<Collider>())
        {
            m_buttonB2.OnButtonPressed();
        }
        else if (hit.collider == m_buttonB3.GetComponent<Collider>())
        {
            m_buttonB3.OnButtonPressed();
        }
        else if (hit.collider == m_buttonC1.GetComponent<Collider>())
        {
            m_buttonC1.OnButtonPressed();
        }
        else if (hit.collider == m_buttonC2.GetComponent<Collider>())
        {
            m_buttonC2.OnButtonPressed();
        }
        else if (hit.collider == m_buttonC3.GetComponent<Collider>())
        {
            m_buttonC3.OnButtonPressed();
        }
        else if (hit.collider == m_buttonD1.GetComponent<Collider>())
        {
            m_buttonD1.OnButtonPressed();
        }
        else if (hit.collider == m_buttonD2.GetComponent<Collider>())
        {
            m_buttonD2.OnButtonPressed();
        }
        else if (hit.collider == m_buttonD3.GetComponent<Collider>())
        {
            m_buttonD3.OnButtonPressed();
        }
        else if (hit.collider == m_sideButton1.GetComponent<Collider>())
        {
            m_sideButton1.OnButtonPressed();
        }
        else if (hit.collider == m_sideButton2.GetComponent<Collider>())
        {
            m_sideButton2.OnButtonPressed();
        }
        else if (hit.collider == m_sideButton3.GetComponent<Collider>())
        {
            m_sideButton3.OnButtonPressed();
        }
        else if (hit.collider == m_sideButton4.GetComponent<Collider>())
        {
            m_sideButton4.OnButtonPressed();
        }
        else if (hit.collider == m_sideButton5.GetComponent<Collider>())
        {
            m_sideButton5.OnButtonPressed();
        }
        else if (hit.collider == m_sideButton6.GetComponent<Collider>())
        {
            m_sideButton6.OnButtonPressed();
        }
        else if (hit.collider == m_sideButton7.GetComponent<Collider>())
        {
            m_sideButton7.OnButtonPressed();
        }
        else if (hit.collider == m_screen.GetComponent<Collider>())
        {
            m_isZooming = !m_isZooming;
            m_animator.SetBool("ZoomInScreen", m_isZooming);
        }
        return Physics.Raycast(m_camera.transform.position, dir, Mathf.Infinity);
    }

    private void UseAccelerator()
    {
        m_accelerator.OnSelected();
    }
    private void temperature()
    {
        m_heater.OnSelected();
    }
    private void ChangeOxygen()
    {
        m_oxygen.OnSelected();
    }
    private void ChangePressure()
    {
        m_pressure.OnSelected();
    }
    private void PullLever()
    {
        m_lever.OnSelected();
    }
    private void PullLever2()
    {
        m_lever2.OnSelected();
    }
    private void PullSwitch1()
    {
        m_switch1.OnSelected();
    }
    private void PullSwitch2()
    {
        m_switch2.OnSelected();
    }
    private void PullSwitch3()
    {
        m_switch3.OnSelected();
    }
    private void PullSwitch4()
    {
        m_switch4.OnSelected();
    }
    private void PullSwitch5()
    {
        m_switch5.OnSelected();
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
            m_oxygen.OnUnSelected();
            m_pressure.OnUnSelected();
            m_lever.OnUnSelected();
            m_lever2.OnUnSelected();
            m_switch1.OnUnSelected();
            m_switch2.OnUnSelected();
            m_switch3.OnUnSelected();
            m_switch4.OnUnSelected();
            m_switch5.OnUnSelected();
        }
        m_dragging = value;
    }
}
