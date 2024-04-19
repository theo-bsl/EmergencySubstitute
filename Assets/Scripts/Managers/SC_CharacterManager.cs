using System.Collections.Generic;
using UnityEngine;

public class SC_CharacterManager : MonoBehaviour
{
    [SerializeField] private List<SO_Character> m_characters;

    private SO_Character m_selectedCharacter;

    public void SelectCharacter(SO_Character Character)
    {
        m_selectedCharacter = Character;
    }

    public SO_Character SelectedCharacter { get { return m_selectedCharacter; } }
}
