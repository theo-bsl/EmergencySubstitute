using UnityEngine;

public abstract class SC_Discreet : SC_Event
{
    public override ResultEndEvent UpdateEvent()
    {
        if (m_canDecreaseTimer)
        {
            EventAction();
            if (m_endTimer < Time.time)
            {
                return m_provokedEvents.Count > 0 ? ResultEndEvent.CreateEvent : ResultEndEvent.GameOver;
            }
        }
        return ResultEndEvent.Nothing;
    }

    protected abstract void EventAction();
}
