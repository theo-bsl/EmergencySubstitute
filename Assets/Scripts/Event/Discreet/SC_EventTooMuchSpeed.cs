public class SC_EventTooMuchSpeed : SC_EventDiscreet
{
    protected override void InitEvent()
    {
        m_eventDuration = 30f;
        m_resolutionTimer = 0f;
        m_name = "TooMuchSpeed";
        m_canDecreaseTimer = true;
    }

    protected override void EventAction() { }
}
