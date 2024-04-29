using UnityEngine;

[CreateAssetMenu(fileName = "EventCrisis", menuName = "ScriptableObjects/Event/EventCrisis", order = 1)]
public class SC_EventCrisis : SC_Event
{
    [SerializeField]
    private float m_increasePercentage = 0f;

    public override ResultEndEvent UpdateEvent()
    {
        SC_CrisisGaugeManager.Instance.IncreaseGauge(m_increasePercentage);
        SC_EventActionManager.Instance.Action(m_eventAction);
        return ResultEndEvent.Nothing;
    }

    public float IncreasePercentage { get { return m_increasePercentage; } }
}
