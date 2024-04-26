using UnityEngine;

public abstract class SC_Event : ScriptableObject
{
    //Fonction Var
    protected bool m_isGettingProcessed = false;

    [SerializeField]
    protected float m_resolutionTimer = 0f;

    [SerializeField]
    protected float m_eventDuration = 0f;
    protected float m_eventTimer = 0f;

    [SerializeField]
    protected float m_increasePercentage = 0f;

    [SerializeField]
    protected Profession m_profession;

    [SerializeField]
    protected bool m_isVisible = false;


    //Graphic Var
    [SerializeField]
    protected Sprite m_icon;

    [SerializeField]
    protected string m_name;

    [SerializeField]
    protected Rooms m_room;

    [SerializeField]
    protected Color m_dificulty;

    //Getters
    public float ResolutionTimer { get { return m_resolutionTimer; } set { m_resolutionTimer = value; } }
    public float EventTimer { get { return m_eventTimer; }}
    public float EventDuration { get { return m_eventDuration; }}   
    public float IncreasePercentage { get { return m_increasePercentage; }}
    public Profession Profession { get { return m_profession; }}
    public bool IsGettingProcessed { get { return m_isGettingProcessed; } set { m_isGettingProcessed = value; } }
    public bool IsVisible { get { return m_isVisible; } }
    public Sprite Icon { get { return m_icon; }}
    public string Name { get { return m_name; }}
    public Rooms Room { get { return m_room; } }
    public Color Dificulty {  get { return m_dificulty; }}

    public void StartEvent()
    {
        InitEvent();

        m_eventTimer = m_eventDuration;
    }

    protected abstract void InitEvent();
    public abstract ResultEndEvent UpdateEvent();
    protected abstract void EventAction();
}
