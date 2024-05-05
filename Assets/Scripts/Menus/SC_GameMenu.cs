using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_GameMenu : MonoBehaviour
{
    public static SC_GameMenu Instance;

    private bool m_inMenu = true;

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

    [SerializeField]
    private GameObject m_sitePopup;

    [SerializeField]
    private GameObject m_firstTextSitePopup;

    [SerializeField]
    private GameObject m_secondeTextSitePopup;

    [SerializeField]
    private GameObject m_tutoOpenUi;

    [SerializeField]
    private GameObject m_tutoZoomScreen;

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

        Time.timeScale = 0.0f;
    }

    public void SettingsMenu()
    {
        m_characterMenu.SetActive(false);
        m_mapMenu.SetActive(false);
    }

    public void MapMenu()
    {
        m_characterMenu.SetActive(!m_characterMenu.activeSelf);
        m_mapMenu.SetActive(!m_mapMenu.activeSelf);
        m_inMenu = m_mapMenu.activeSelf || m_characterMenu.activeSelf || m_tutorialMenu.activeSelf;

        if (!m_hasSeenTutorial && m_characterMenu.activeSelf)
        {
            m_tutorialMenu.SetActive(true);
            Time.timeScale = 0.0f;
        }
    }

    public void CloseTutorial()
    {
        m_tutorialMenu.SetActive(false);
        m_hasSeenTutorial = true;
        m_inMenu = m_mapMenu.activeSelf || m_characterMenu.activeSelf || m_tutorialMenu.activeSelf;
        Time.timeScale = 1.0f;
    }

    public void NextDialogueSitePopup()
    {
        if (m_firstTextSitePopup.activeSelf)
        {
            m_firstTextSitePopup.SetActive(false);
            m_secondeTextSitePopup.SetActive(true);
        }
        else
        {
            m_sitePopup.SetActive(false);
            m_inMenu = false;
            Time.timeScale = 1.0f;
            OpenTutorialOpenUI();
        }
    }

    public void OpenTutorialOpenUI()
    {
        m_tutoOpenUi.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void CloseTutorialOpenUI()
    {
        m_tutoOpenUi.SetActive(false);
        Time.timeScale = 1.0f;
        OpenTutorialZoomScreen();
    }

    public void OpenTutorialZoomScreen()
    {
        m_tutoZoomScreen.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void CloseTutorialZoomScreen()
    {
        m_tutoZoomScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }

    private void ShowWinMenu()
    {
        m_winMenu.SetActive(true);
        m_inMenu = true;
    }

    public void HideBackToMenu()
    {
        m_backToMenuPopup.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void BackToMenu()
    {
        Time.timeScale = 1.0f;
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