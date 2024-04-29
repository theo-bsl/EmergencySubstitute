using UnityEngine;

[CreateAssetMenu(fileName = "EventFatal", menuName = "ScriptableObjects/Event/EventFatal", order = 1)]
public class SC_EventFatal : SC_Event
{
    [SerializeField]
    private float m_eventDuration = 0f;

    public override ResultEndEvent UpdateEvent()
    {
        m_eventDuration -= Time.deltaTime;
        if (m_eventDuration <= 0f)
        {
            return ResultEndEvent.GameOver;
        }
        SC_EventActionManager.Instance.Action(m_eventAction);
        return ResultEndEvent.Nothing;
    }
}
