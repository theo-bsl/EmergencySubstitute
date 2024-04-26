using UnityEngine;

public abstract class SC_EventFatal : SC_Event
{
    public override ResultEndEvent UpdateEvent()
    {
        m_eventTimer -= Time.deltaTime;
        if (m_eventTimer <= 0f)
        {
            return ResultEndEvent.GameOver;
        }

        return ResultEndEvent.Nothing;
    }
}
