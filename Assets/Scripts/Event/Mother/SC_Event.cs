using System.Collections.Generic;
using UnityEngine;

public abstract class SC_Event
{
    //Fonction Var
    protected List<SC_Event> m_provokedEvents = new List<SC_Event>();
    protected float m_resolutionTimer = 0f;
    protected float m_beginningTimer = 0f;
    protected float m_endTimer = 0f;
    protected float m_eventDuration = 0f;
    protected SC_ProfessionEnum.Profession m_profession;
    protected bool m_hasTimer = false;
    protected bool m_canDecreaseTimer = true;

    //Graphic Var
    protected Sprite m_icon;
    protected string m_name;
    protected Rooms m_room;
    protected Color m_dificulty;

    //Getters
    public List<SC_Event> ProvokedEvents {get { return m_provokedEvents;}}
    public float ResolutionTimer { get { return m_resolutionTimer; } set { m_resolutionTimer = value; } }
    public float BeginningTimer { get { return m_beginningTimer; }}
    public float EventDuration { get { return m_eventDuration; }}   
    public float EndTimer { get { return m_endTimer; } set { m_endTimer = value; } }
    public SC_ProfessionEnum.Profession Profession { get { return m_profession; }}
    public bool HasTimer { get { return m_hasTimer; }}
    public Sprite Icon { get { return m_icon; }}
    public string Name { get { return m_name; }}
    public Rooms Room { get { return m_room; }}
    public Color Dificulty {  get { return m_dificulty; }}

    public void StartEvent()
    {
        InitEvent();

        m_beginningTimer = Time.time;
        m_endTimer = m_beginningTimer + m_eventDuration;
    }

    protected abstract void InitEvent();
    public abstract ResultEndEvent UpdateEvent();


    public void StopTimer()
    {
        m_canDecreaseTimer = false;
    }
}
