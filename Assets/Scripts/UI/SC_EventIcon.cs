using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SC_EventIcon : MonoBehaviour
{
    private SC_Event m_event;
    private SO_Character m_character;
    private string m_name;
    private UnityEvent<string> m_showDescription = new UnityEvent<string>();
    public string Name { get { return m_name; } }

    public void InitEventIcon(SC_Event Event)
    {
        SC_EventProcessor.Instance.UpdateCharacterAttribution.AddListener(ResetAttribution);
        m_event = Event;
        GetComponent<Image>().sprite = m_event.Icon;
        m_name = m_event.Name;
    }

    public void ProcessEventIcon()
    {
        SC_EventProcessor.Instance.ProcessEvent(m_event, m_character);
    }
    public void OnMouseEnter()
    {
        m_event.EventParagraph;
    }
    public void ChangeCharacterAttribution()
    {
        SO_Character Character = SC_CharacterManager.Instance.SelectedCharacter;

        if (Character != null)
        {
            if (Character.IsAvailable && !m_event.IsGettingProcessed && !SC_EventProcessor.Instance.IsConfirming)
            {
                m_character = Character;
                SC_CharacterManager.Instance.SelectCharacter(null);
                transform.GetChild(0).GetComponent<Image>().sprite = m_character.Icon;
                transform.GetChild(0).gameObject.SetActive(true);
                SC_EventProcessor.Instance.GreyCharacter(m_character);
                ShowConfirmation();
            }
        }
    }

    public void ShowConfirmation()
    {
        SC_EventProcessor.Instance.IsConfirming = true;
        transform.GetChild(1).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(true);
    }

    public void HideConfirmation()
    {
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
        SC_EventProcessor.Instance.IsConfirming = false;
    }

    public void ResetConfirmation()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        SC_EventProcessor.Instance.GreyCharacter(m_character);
        m_character = null;
    }

    private void ResetAttribution(SC_Event Event)
    {
        if (Event == m_event)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

}