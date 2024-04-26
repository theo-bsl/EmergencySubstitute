public class SC_EventAutopilotHS : SC_EventFatal
{
    protected override void InitEvent()
    {
        m_eventDuration = 20f;
        m_resolutionTimer = 5f;
        m_name = "AutopilotHS";
        m_room = Rooms.Cockpit;
        m_profession = Profession.Informatician;
    }

    protected override void EventAction() { }
}
