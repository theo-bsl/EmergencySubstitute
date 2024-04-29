public class SC_ShipBodyBroke : SC_EventFatal
{
    private float m_oxygenDecrease = 1f / 2f; //Variable temporaire
    private float m_pressureDecrease = 1f / 2f; //Variable temporaire
    protected override void InitEvent()
    {
        m_eventDuration = 20f;
        m_resolutionTimer = 5f;
        m_name = "BodyBreaking";
        m_profession = Profession.Mechanic;
        m_room = Rooms.Cabin;
        m_canDecreaseTimer = true;
    }

    protected override void EventAction()
    {
        //SC_StarshipManager.Instance.ChangeOxygen(m_oxygenDecrease);
        //SC_StarshipManager.Instance.ChangePressure(m_pressureDecrease);
    }

}
