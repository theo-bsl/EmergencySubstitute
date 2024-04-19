using UnityEngine;

public abstract class SC_EventFatal : SC_Event
{
    public override ResultEndEvent UpdateEvent()
    {
        if (m_canDecreaseTimer)
        {
            if (m_endTimer < Time.time)
            {
                return ResultEndEvent.GameOver;
            }
        }
        return ResultEndEvent.Nothing;
    }
}
