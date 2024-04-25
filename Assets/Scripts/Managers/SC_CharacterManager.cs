using System.Collections.Generic;
using UnityEngine;

public class SC_CharacterManager : MonoBehaviour
{
    public static SC_CharacterManager Instance;

    [SerializeField] private List<SO_Character> m_characters;

    private SO_Character m_selectedCharacter;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < m_characters.Count; i++)
        {
            m_characters[i].WorkTime = 0;
        }
    }

    public void SelectCharacter(SO_Character Character)
    {
        m_selectedCharacter = Character;
    }

    public SO_Character SelectedCharacter { get { return m_selectedCharacter; } }
    
    public List<SO_Character> Characters { get { return m_characters; } }
}
