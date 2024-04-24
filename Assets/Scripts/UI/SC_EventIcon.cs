using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SC_EventIcon : MonoBehaviour
{
    private SC_Event m_event;
    private string m_name;

    public string Name { get { return m_name; } }

    public void InitEventIcon(SC_Event Event)
    {
        GetComponent<Image>().sprite = Event.Icon;
        m_event = Event;
        m_name = Event.Name;
    }

    public void ProcessEventIcon()
    {
        SC_EventProcessor.Instance.ProcessEvent(m_event);
    }

}
