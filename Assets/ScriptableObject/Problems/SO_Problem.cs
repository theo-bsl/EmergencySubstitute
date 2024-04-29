using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Problem", menuName = "ScriptableObjects/Problem", order = 1)]
public class SO_Problem : ScriptableObject
{
    [SerializeField]
    List<SC_Event> m_events = new List<SC_Event>();

    [SerializeField] 
    List<SC_Event> m_blockerEvents = new List<SC_Event>();

    public List<SC_Event> Events {  get { return m_events; } }

    public List<SC_Event> BlockerEvents { get { return m_blockerEvents; } }
}
