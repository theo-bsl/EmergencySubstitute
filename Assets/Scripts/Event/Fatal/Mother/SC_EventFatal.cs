using UnityEngine;

[CreateAssetMenu(fileName = "EventFatal", menuName = "ScriptableObjects/Event/EventFatal", order = 1)]
public class SC_EventFatal : SC_Event
{
    [SerializeField]
    private float m_eventDuration = 0f;
    private float m_eventTimer = 0f;

    public override ResultEndEvent UpdateEvent()
    {
        m_eventTimer -= Time.deltaTime;
        if (m_eventTimer <= 0f)
        {
            return ResultEndEvent.GameOver;
        }
        SC_EventActionManager.Instance.Action(m_eventAction);
        return ResultEndEvent.Nothing;
    }

    public override void StartEvent()
    {
        m_eventTimer = m_eventDuration;
    }

    public float EventDuration { get { return m_eventDuration; } }
}
