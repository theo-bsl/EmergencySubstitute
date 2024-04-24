using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SC_UIEvent : MonoBehaviour
{
    private SC_Event m_event;
    private Image m_eventIcon;
    private TextMeshProUGUI m_name;

    public string Name { get { return m_name.text; } }

    private void Start()
    {
        m_eventIcon = transform.GetChild(0).GetComponent<Image>();
        m_name = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void InitEventIcon(SC_Event Event)
    {
        m_event = Event;
        m_eventIcon.sprite = Event.Icon;
        m_name.text = Event.Name;
    }

}
