using UnityEngine;

public class SC_CockpitInteractables : MonoBehaviour
{
    [SerializeField] private GameObject m_accelerator;
    [SerializeField] private GameObject m_orientationL;
    [SerializeField] private GameObject m_orientationR;
    [SerializeField] private GameObject m_circuitBreaker;
    [SerializeField] private GameObject m_heater;
    [SerializeField] private GameObject m_radio;
    [SerializeField] private GameObject m_joystick;
    [SerializeField] private GameObject m_lights;
    [SerializeField] private GameObject m_radioFrequency;
    [SerializeField] private GameObject m_microphone;
    private Vector3 m_mousePos;
    private Camera m_camera;

    private void Start()
    {
        m_camera = Camera.main;
    }

    private void Update()
    {
        m_mousePos = m_camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1f));
    }

    public void CheckForInteractable()
    {
        Vector3 dir = m_mousePos - m_camera.transform.position;
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
    }

    private void UseAccelerator()
    {
        Debug.Log("used accelerator");
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
        Debug.Log("heat up");
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
        Debug.Log("Changed Frequency");
    }
    private void MicOnOff()
    {
        Debug.Log("Mic");
    }
}
