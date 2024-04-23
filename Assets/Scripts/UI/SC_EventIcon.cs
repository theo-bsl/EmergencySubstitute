using UnityEngine;

public class SC_EventIcon : MonoBehaviour
{
    private SC_Event m_event;
    private Sprite m_eventIcon;

    public void ProcessEventIcon()
    {
        SC_EventProcessor.Instance.ProcessEvent(m_event);
    }
}
