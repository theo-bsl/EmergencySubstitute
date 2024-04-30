using UnityEngine;
using UnityEngine.UI;

public class SC_EventIcon : MonoBehaviour
{
    private SC_Event m_event;
    private string m_name;

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
        SC_EventProcessor.Instance.ProcessEvent(m_event);
    }

    public void ChangeCharacterAttribution()
    {
        SO_Character Character = SC_CharacterManager.Instance.SelectedCharacter;

        if (Character != null)
        {
            if (Character.IsAvailable && !m_event.IsGettingProcessed)
            {
                transform.GetChild(0).GetComponent<Image>().sprite = Character.Icon;
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }

    private void ResetAttribution(SC_Event Event)
    {
        if (Event == m_event)
        {
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

}