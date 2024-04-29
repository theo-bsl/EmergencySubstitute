using UnityEngine;

public abstract class SC_Event : ScriptableObject
{
    //Fonction Var
    protected bool m_isGettingProcessed = false;

    [SerializeField]
    protected float m_resolutionTimer = 0f;

    [SerializeField]
    protected Profession m_profession;

    [SerializeField]
    protected EventAction m_eventAction;

    [SerializeField]
    protected bool m_isVisible = true;


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
    public Profession Profession { get { return m_profession; }}
    public bool IsGettingProcessed { get { return m_isGettingProcessed; } set { m_isGettingProcessed = value; } }
    public bool IsVisible { get { return m_isVisible; } }
    public Sprite Icon { get { return m_icon; }}
    public string Name { get { return m_name; }}
    public Rooms Room { get { return m_room; } }
    public Color Dificulty {  get { return m_dificulty; }}

    public abstract ResultEndEvent UpdateEvent();
}
