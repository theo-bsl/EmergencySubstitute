using System.Collections.Generic;
using UnityEngine;

public class SC_CharacterMenuManager : MonoBehaviour
{
    [SerializeField]
    private List<SC_UICharacter> m_characters = new List<SC_UICharacter>();

    private void Start()
    {
        for (int i = 0 ; i < m_characters.Count; i++)
        {
            SO_Character Character = SC_CharacterManager.Instance.Characters[i];
            m_characters[i].InitCharacter(Character.Name, Character.Icon);
        }

        SC_EventProcessor.Instance.UpdateCharacterWorkTime.AddListener(UpdateWorkTime);
    }

    public void UpdateWorkTime(SO_Character Character, float EventDuration, float WorkTime)
    {
        for (int i = 0 ;i < m_characters.Count; i++)
        {
            if (m_characters[i].Name == Character.Name)
            {
                m_characters[i].UpdateWorkTime(EventDuration, WorkTime);
                break;
            }
        }
    }
}
