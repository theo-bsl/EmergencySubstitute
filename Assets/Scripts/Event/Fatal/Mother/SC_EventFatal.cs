using UnityEngine;

public abstract class SC_EventFatal : SC_Event
{
    protected override int UpdateEvent()
    {
        if (m_canDecreaseTimer)
        {
            if (m_endTimer < Time.time)
            {
                return -1;
            }
        }
        return 0;
    }
}
