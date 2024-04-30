using TMPro;
using UnityEngine;

public class SC_GameMenu : MonoBehaviour
{
    private bool m_inMenu = false;

    [Header("Menus")]
    [SerializeField]
    private GameObject m_settingsMenu;

    [SerializeField]
    private GameObject m_characterMenu;

    [SerializeField]
    private GameObject m_mapMenu;

    [SerializeField]
    private GameObject m_winMenu;

    [SerializeField]
    private TextMeshProUGUI m_loseMessage;

    public bool InMenu { get { return m_inMenu; } }
    private void Start()
    {
        CloseAllMenus();

        SC_GameManager.Instance.GameWin.AddListener(ShowWinMenu);
        SC_GameManager.Instance.GameLose.AddListener(ShowLoseMenu);
    }

    public void SettingsMenu()
    {
        bool MenuState = m_settingsMenu.activeSelf;
        CloseAllMenus();
        m_settingsMenu.SetActive(!MenuState);
    }

    public void CharacterMenu()
    {
        bool MenuState = m_characterMenu.activeSelf;
        CloseAllMenus();
        m_characterMenu.SetActive(!MenuState);
    }

    public void MapMenu()
    {
        bool MenuState = m_mapMenu.activeSelf;
        CloseAllMenus();
        m_mapMenu.SetActive(!MenuState);
    }

    private void CloseAllMenus()
    {
        m_characterMenu.SetActive(false);
        m_mapMenu.SetActive(false);
        m_settingsMenu.SetActive(false);
    }

    private void ShowWinMenu()
    {
        m_winMenu.SetActive(true);
    }

    private void ShowLoseMenu(string LoseMessage)
    {
        m_loseMessage.text = LoseMessage;
        m_loseMessage.transform.parent.gameObject.SetActive(true);
    }
}