using UnityEngine;
using UnityEngine.InputSystem;

public class SC_PlayerInput : MonoBehaviour
{
    private Vector3 m_mousePos;
    private Vector3 m_dragDist = Vector3.zero;
    private Camera m_camera;

    [SerializeField]
    private GameObject m_backToMenuPopup;

    private void Start()
    {
        m_camera = Camera.main;
    }
    public void OnMouseButtonLeftDown(InputAction.CallbackContext context)
    {
        if (context.started && !SC_GameMenu.Instance.InMenu)
        {
            SC_StarshipController.Instance.SetIsDragging(true);
            SC_StarshipController.Instance.CheckForInteractable(m_mousePos);
        }
        if (context.canceled && !SC_GameMenu.Instance.InMenu)
        {
            SC_StarshipController.Instance.SetIsDragging(false);
        }
    }

    public void MousePos(InputAction.CallbackContext context)
    {
        m_mousePos = m_camera ? m_camera.ScreenToWorldPoint(new Vector3(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y, 1f)) : m_mousePos;
    }

    public void MouseDelta(InputAction.CallbackContext context)
    {
        m_dragDist = context.ReadValue<Vector2>();
        SC_StarshipController.Instance.SetDragDist(m_dragDist);
    }

    public void ShowBackToMenuPopup()
    {
        m_backToMenuPopup.SetActive(true);
    }
}
