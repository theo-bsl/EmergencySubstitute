using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SC_MainMenu : MonoBehaviour
{
    private Vector3 m_mousePos;

    [SerializeField]
    private Camera m_camera;

    [SerializeField]
    private GameObject m_spaceShip1;

    [SerializeField]
    private GameObject m_spaceShip2;

    [SerializeField]
    private GameObject m_spaceShip3;

    [SerializeField]
    private GameObject m_exit;

    [SerializeField] 
    private Animator m_animator;

    [SerializeField]
    private GameObject m_beginMissionMenu;

    [SerializeField]
    private GameObject m_confirmQuit;

    public void OnMouseButtonLeftDownInMenu(InputAction.CallbackContext context)
    {
        if (context.started && !m_beginMissionMenu.activeSelf && !m_confirmQuit.activeSelf)
        {
            Vector3 dir = m_mousePos - m_camera.transform.position;
            Physics.Raycast(m_camera.transform.position, dir, out RaycastHit hit, Mathf.Infinity);
            Debug.DrawRay(m_camera.transform.position, dir * 1000, Color.green, 100);
            
            ResetAllTriggers();

            if (hit.collider == m_spaceShip1.GetComponent<Collider>()) 
            {
                m_animator.SetTrigger("Ship1");
                m_beginMissionMenu.SetActive(true);
            }
            else if (hit.collider == m_spaceShip2.GetComponent<Collider>())
            {
                m_animator.SetTrigger("Ship2");
                m_beginMissionMenu.SetActive(true);
            }
            else if (hit.collider == m_spaceShip3.GetComponent<Collider>())
            {
                m_animator.SetTrigger("Ship3");
                m_beginMissionMenu.transform.GetChild(0).GetComponent<Button>().interactable = true;
                m_beginMissionMenu.SetActive(true);
            }
            else if (hit.collider == m_exit.GetComponent<Collider>())
            {
                m_confirmQuit.SetActive(true);
            }

        }
    }

    private void ResetAllTriggers()
    {
        m_animator.ResetTrigger("Ship1");
        m_animator.ResetTrigger("Ship2");
        m_animator.ResetTrigger("Ship3");
    }

    public void BackFromShip()
    {
        ResetAllTriggers();
        m_animator.SetTrigger("Back");
        m_beginMissionMenu.transform.GetChild(0).GetComponent<Button>().interactable = false;
        m_beginMissionMenu.SetActive(false);
    }

    public void LoadMission1()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void BackFromQuit()
    {
        m_confirmQuit.SetActive(false);
    }

    public void MousePosInMenu(InputAction.CallbackContext context)
    {
        m_mousePos = m_camera.ScreenToWorldPoint(new Vector3(context.ReadValue<Vector2>().x, context.ReadValue<Vector2>().y, 1f));
    }
}
