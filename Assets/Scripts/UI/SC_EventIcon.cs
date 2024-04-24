using UnityEngine;
using UnityEngine.UI;

public class SC_EventIcon : MonoBehaviour
{
    private SC_Event m_event;
    private string m_name;

    public string Name { get { return m_name; } }

    public void InitEventIcon(SC_Event Event)
    {
        m_event = Event;
        GetComponent<Image>().sprite = m_event.Icon;
        m_name = m_event.Name;
    }

    public void ProcessEventIcon()
    {
        SC_EventProcessor.Instance.ProcessEvent(m_event);
    }

}
