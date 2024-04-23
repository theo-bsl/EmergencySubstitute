public class SC_ShipBodyBroke : SC_EventFatal
{
    private float m_oxygenDecrease = 1 / 2; //Variable temporaire
    private float m_pressureDecrease = 1 / 2; //Variable temporaire
    protected override void InitEvent()
    {
        m_eventDuration = 20f;
        m_resolutionTimer = 5f;
        m_name = "BodyBreaking";
        m_profession = SC_ProfessionEnum.Profession.Mechanic;
        m_canDecreaseTimer = true;
    }

    protected override void EventAction()
    {
        SC_StarshipManager.Instance.ChangeOxygen(m_oxygenDecrease);
        SC_StarshipManager.Instance.ChangePressure(m_pressureDecrease);
    }

}
