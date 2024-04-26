public class SC_EventTooMuchSpeed : SC_EventFatal
{
    protected override void InitEvent()
    {
        m_eventDuration = 30f;
        m_resolutionTimer = 0f;
        m_name = "TooMuchSpeed";
    }

    protected override void EventAction() { }
}
