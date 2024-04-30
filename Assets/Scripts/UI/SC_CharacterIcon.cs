using UnityEngine;
using UnityEngine.UI;

public class SC_CharacterIcon : MonoBehaviour
{
    [SerializeField]
    private SO_Character m_character;

    public void InitCharacterIcon(SO_Character Character)
    {
        SC_EventProcessor.Instance.GreyOutCharacter.AddListener(ProcessCharacter);
        m_character = Character;
        GetComponent<Image>().sprite = m_character.Icon;
    }

    public void SetCharacterSelected()
    {
        SC_CharacterManager.Instance.SelectCharacter(m_character);
    }

    private void ProcessCharacter(SO_Character Character)
    {
        if (Character == m_character) 
        { 
            GetComponent<Button>().interactable = !GetComponent<Button>().interactable;
        }
    }
}