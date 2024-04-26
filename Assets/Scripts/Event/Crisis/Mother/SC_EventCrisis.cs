using UnityEngine;

public abstract class SC_EventCrisis : SC_Event
{
    public override ResultEndEvent UpdateEvent()
    {
        SC_CrisisGaugeManager.Instance.IncreaseGauge(m_increasePercentage);

        return ResultEndEvent.Nothing;
    }
}
