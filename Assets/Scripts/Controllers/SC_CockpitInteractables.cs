using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SC_CockpitInteractables : MonoBehaviour
{
    /*private bool m_adf;
    private bool m_mic;
    private bool m_lights;
    private Slider m_radioFrequency;
    private Slider m_lever;
    private bool m_radio;
    private Slider m_airConditioning;
    private bool m_circuit;
    private bool m_orientationL;
    private bool m_orientationR;
    private Slider m_acceleration;*/
    [SerializeField] private GameObject m_accelerator;
    [SerializeField] private GameObject m_orientationL;
    [SerializeField] private GameObject m_orientationR;
    private Vector3 m_mousePos;

    private void Update()
    {
        m_mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f));
        if (Input.GetMouseButtonDown(0))
        {
            CheckForInteractable();
        }
    }

    private void CheckForInteractable()
    {
        RaycastHit hit;
        Physics.Raycast(m_mousePos, Vector3.forward, out hit);
        if (hit.collider == m_accelerator.GetComponent<Collider>())
        {
            UseAccelerator();
        }
    }

    private void UseAccelerator()
    {
        Debug.Log("used accelerator");
    }
}
