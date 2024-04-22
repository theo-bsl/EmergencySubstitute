public class SC_EventLowCoolantLevel : SC_EventFatal
{
    protected override void InitEvent()
    {
        m_eventDuration = 20f;
        m_resolutionTimer = 5f;
        m_name = "LowCoolantLevel";
        m_profession = SC_ProfessionEnum.Profession.Mechanic;
        m_canDecreaseTimer = true;
    }

}
