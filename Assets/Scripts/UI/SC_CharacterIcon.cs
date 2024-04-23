using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class SC_CharacterIcon : MonoBehaviour
{
    // Old Script for Drag And Drop
    ////////////
    /*
    private Camera m_mainCamera;

    private Sprite m_characterIcon;

    [SerializeField]
    private GameObject m_characterIconPrefab;

    private GameObject m_currentCharacterSpawned;

    private void Start()
    {
        m_characterIcon = GetComponent<Image>().sprite;
        m_mainCamera = Camera.main;
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse Is Down !");
        GetComponent<Image>().color = new Color(1,1,1,0);
        m_currentCharacterSpawned = Instantiate(m_characterIconPrefab);
        m_currentCharacterSpawned.GetComponent<Image>().sprite = m_characterIcon;
    }

    private void OnMouseDrag()
    {
        Debug.Log("Mouse Drag !");
        if (m_currentCharacterSpawned)
        {
            Vector3 NewIconPos = m_mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1f));
            m_currentCharacterSpawned.transform.position = NewIconPos;
        }
    }

    private void OnMouseUp()
    {
        Destroy(m_currentCharacterSpawned);
        GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }
    */
    ////////////
    [SerializeField]
    private SO_Character m_character;


    public void InitCharacterIcon(SO_Character Character)
    {
        GetComponent<Image>().sprite = Character.Icon;
        m_character = Character;
    }

    public void SetSelectableCharacter()
    {
        SC_CharacterManager.Instance.SelectCharacter(m_character);
    }



}
