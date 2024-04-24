using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SC_UIEvent : MonoBehaviour
{
    private SC_Event m_event;

    [SerializeField]
    private Image m_eventIcon;

    [SerializeField]
    private TextMeshProUGUI m_name;

    public string Name { get { return m_name.text; } }

    public void InitEventIcon(SC_Event Event)
    {
        m_event = Event;
        m_eventIcon.sprite = m_event.Icon;
        m_name.text = m_event.Name;
    }

}
