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
    private Image m_workTime;

    [SerializeField]
    private Button m_button;

    public void InitCharacterIcon(SO_Character Character)
    {
        SC_EventProcessor.Instance.GreyOutCharacter.AddListener(ProcessCharacter);
        m_character = Character;
        m_head.sprite = m_character.Icon;
        m_textName.text = m_character.Name;
        m_name = m_character.Name;
    }

    public void SetCharacterSelected()
    {
        SC_CharacterManager.Instance.SelectCharacter(m_character);
    }

    private void ProcessCharacter(SO_Character Character)
    {
        if (Character == m_character) 
        {
            m_button.interactable = !m_button.interactable;
        }
    }

    public void UpdateWorkTime(float EventDuration, float WorkTime)
    {
        m_workTime.fillAmount = WorkTime / EventDuration;
    }
    public string Name { get { return m_name; } }
}