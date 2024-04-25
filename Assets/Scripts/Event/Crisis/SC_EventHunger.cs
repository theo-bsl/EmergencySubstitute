public class SC_EventHunger : SC_EventCrisis
{
    protected override void InitEvent()
    {
        m_increasePercentage = 1/3;
        m_resolutionTimer = 10;
        m_name = "Hunger";
        m_profession = Profession.Cook;
        m_room = Rooms.Kitchen;
    }

    protected override void EventAction() { }
}
