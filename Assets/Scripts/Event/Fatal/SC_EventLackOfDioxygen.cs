public class SC_EventLackOfDioxygen : SC_EventFatal
{
    protected override void InitEvent()
    {
        m_eventDuration = 30f;
        m_resolutionTimer = 0f;
        m_name = "LackOfDioxygen";
    }

    protected override void EventAction() { }
}
