using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_GameMenu : MonoBehaviour
{
    public static SC_GameMenu Instance;

    private bool m_inMenu = false;

    [Header("Menus")]

    [SerializeField]
    private GameObject m_characterMenu;

    [SerializeField]
    private GameObject m_mapMenu;

    [SerializeField]
    private GameObject m_winMenu;

    [SerializeField]
    private GameObject m_tutorialMenu;

    [SerializeField]
    private TextMeshProUGUI m_loseMessage;

    [SerializeField]
    private GameObject m_backToMenuPopup;

    private bool m_hasSeenTutorial = false;

    public bool InMenu { get { return m_inMenu; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        m_characterMenu.SetActive(false);
        m_mapMenu.SetActive(false);

        SC_GameManager.Instance.GameWin.AddListener(ShowWinMenu);
        SC_GameManager.Instance.GameLose.AddListener(ShowLoseMenu);
    }

    public void SettingsMenu()
    {
        m_characterMenu.SetActive(false);
        m_mapMenu.SetActive(false);
    }

    public void CharacterMenu()
    {
        m_characterMenu.SetActive(!m_characterMenu.activeSelf);
        m_inMenu = m_mapMenu.activeSelf || m_characterMenu.activeSelf;

        if (!m_hasSeenTutorial && m_mapMenu.activeSelf)
        {
            m_tutorialMenu.SetActive(true);
        }
    }

    public void MapMenu()
    {
        m_mapMenu.SetActive(!m_mapMenu.activeSelf);
        m_inMenu = m_mapMenu.activeSelf || m_characterMenu.activeSelf;

        if (!m_hasSeenTutorial && m_characterMenu.activeSelf)
        {
            m_tutorialMenu.SetActive(true);
        }
    }

    public void CloseTutorial()
    {
        m_tutorialMenu.SetActive(false);
        m_hasSeenTutorial = true;
    }

    private void ShowWinMenu()
    {
        m_winMenu.SetActive(true);
        m_inMenu = true;
    }

    public void HideBackToMenu()
    {
        m_backToMenuPopup.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void Replay()
    {
        //Reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void ShowLoseMenu(string LoseMessage)
    {
        m_inMenu = true;
        m_loseMessage.text = LoseMessage;
        m_loseMessage.transform.parent.gameObject.SetActive(true);
    }
}