public class SC_EventEpidemic : SC_EventFatal
{
    protected override void InitEvent()
    {
        m_eventDuration = 20f;
        m_resolutionTimer = 5f;
        m_name = "Epidemic";
        m_profession = Profession.Doctor;
        m_room = Rooms.Infirmary;
        m_canDecreaseTimer = true;
    }
    protected override void EventAction() { }
}
