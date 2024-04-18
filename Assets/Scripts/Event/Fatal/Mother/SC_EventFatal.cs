using UnityEngine;

public abstract class SC_EventFatal : SC_Event
{
    private void Update()
    {
        if (m_canDecreaseTimer)
        {
            if (m_endTimer < Time.time)
            {
                EndEvent();
            }
        }
    }

    private void EndEvent()
    {
        Debug.Log(m_name + "is finished");
    }
}
