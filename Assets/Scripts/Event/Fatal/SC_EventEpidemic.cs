using UnityEngine;

[CreateAssetMenu(fileName = "EventEpidemic", menuName = "ScriptableObjects/Event", order = 1)]
public class SC_EventEpidemic : SC_EventFatal
{
    protected override void InitEvent()
    {
        m_eventDuration = 20f;
        m_resolutionTimer = 5f;
        m_name = "Epidemic";
        m_profession = Profession.Doctor;
        m_room = Rooms.Infirmary;
    }
    protected override void EventAction() { }
}
