using UnityEngine;

public abstract class SC_EventCrisis : SC_Event
{
    protected float m_increasePercentage;
    public override ResultEndEvent UpdateEvent()
    {
        SC_CrisisGaugeManager.Instance.IncreaseGauge(m_increasePercentage * Time.deltaTime);
        return ResultEndEvent.Nothing;
    }
}
