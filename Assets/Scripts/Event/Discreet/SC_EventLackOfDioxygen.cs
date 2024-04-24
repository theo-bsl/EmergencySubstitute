public class SC_EventLackOfDioxygen : SC_EventDiscreet
{
    protected override void InitEvent()
    {
        m_eventDuration = 30f;
        m_resolutionTimer = 0f;
        m_name = "LackOfDioxygen";
        m_canDecreaseTimer = true;
    }

    protected override void EventAction() { }
}
