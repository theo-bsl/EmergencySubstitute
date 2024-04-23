public class SC_EventLowCoolantLevel : SC_EventFatal
{
    private float m_temperatureChange = 1 / 2;
    protected override void InitEvent()
    {
        m_eventDuration = 20f;
        m_resolutionTimer = 5f;
        m_name = "LowCoolantLevel";
        m_profession = SC_ProfessionEnum.Profession.Mechanic;
        m_canDecreaseTimer = true;
    }

    protected override void EventAction()
    {
        SC_StarshipManager.Instance.ChangeTemperature(m_temperatureChange);
    }
}
