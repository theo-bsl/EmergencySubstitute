using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SC_CharacterIcon : MonoBehaviour
{
    [SerializeField]
    private SO_Character m_character;

    [SerializeField]
    private TextMeshProUGUI m_textName;
    private string m_name;

    [SerializeField]
    private Image m_head;

    [SerializeField]
    private Image m_headOutline;

    [SerializeField]
    private Image m_workTime;

    [SerializeField]
    private Button m_button;

    public void InitCharacterIcon(SO_Character Character)
    {
        SC_EventProcessor.Instance.GreyOutCharacter.AddListener(ProcessCharacter);
        SC_EventProcessor.Instance.GreyOutCharacter.AddListener(StopTheOutline);
        m_character = Character;
        m_head.sprite = m_character.Icon;
        m_textName.text = m_character.Name;
        m_name = m_character.Name;
    }

    private void Update()
    {
        if (m_character == SC_CharacterManager.Instance.SelectedCharacter)
        {
            m_headOutline.transform.rotation = m_headOutline.transform.rotation * Quaternion.Euler(0,0,0.3f);
        }
        else
        {
            m_headOutline.color = new(m_headOutline.color.r, m_headOutline.color.g, m_headOutline.color.b, 0);
        }
    }

    public void SetCharacterSelected()
    {
        SC_CharacterManager.Instance.SelectCharacter(m_character);
        m_headOutline.color = new(m_headOutline.color.r, m_headOutline.color.g, m_headOutline.color.b, 1);
    }

    private void ProcessCharacter(SO_Character Character)
    {
        if (Character == m_character) 
        {
            m_button.interactable = !m_button.interactable;
        }
    }

    private void StopTheOutline(SO_Character Character)
    {
        m_headOutline.color = new(m_headOutline.color.r, m_headOutline.color.g, m_headOutline.color.b, 0);
    }

    public void UpdateWorkTime(float EventDuration, float WorkTime)
    {
        m_workTime.fillAmount = WorkTime / EventDuration;
    }
    public string Name { get { return m_name; } }
}