using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "ScriptableObjects/Event", order = 1)]
public class SC_Event : ScriptableObject
{
    //Fonction Var
    protected bool m_isGettingProcessed = false;

    [SerializeField]
    protected float m_resolutionTimer = 0f;

    [SerializeField]
    private float m_eventDuration = 0f;

    [SerializeField]
    protected Profession m_profession;

    [SerializeField]
    protected StarshipState m_starshipState;

    [SerializeField]
    protected List<EventAction> m_eventAction = new List<EventAction>();

    [SerializeField]
    protected bool m_isVisible = true;

    //Graphic Var
    [SerializeField]
    protected Sprite m_icon;

    [SerializeField]
    protected string m_name;

    [SerializeField]
    protected string m_deathCharacterPhrase;

    [SerializeField]
    protected string m_deathTimePhrase;

    [SerializeField] 
    protected string m_eventParagraph;

    [SerializeField]
    protected Rooms m_room;

    [SerializeField]
    protected Color m_dificulty;

    //Getters
    public float ResolutionTimer { get { return m_resolutionTimer; } set { m_resolutionTimer = value; } }
    public Profession Profession { get { return m_profession; }}
    public bool IsGettingProcessed { get { return m_isGettingProcessed; } set { m_isGettingProcessed = value; } }
    public List<EventAction> EventAction {  get { return m_eventAction; } set { m_eventAction = value; } }
    public bool IsVisible { get { return m_isVisible; } }
    public Sprite Icon { get { return m_icon; }}
    public string Name { get { return m_name; }}
    public string DeathCharacterPhrase { get { return m_deathCharacterPhrase; } }
    public string DeathTimePhrase { get { return m_deathTimePhrase; } }
    public string EventParagraph { get { return m_eventParagraph; } }
    public Rooms Room { get { return m_room; } }
    public Color Dificulty {  get { return m_dificulty; }}
    public StarshipState StarshipState { get { return m_starshipState; }}

    public ResultEndEvent UpdateEvent()
    {
        m_eventDuration -= Time.deltaTime;
        if (m_eventDuration <= 0f)
        {
            return ResultEndEvent.GameOver;
        }

        for (int i = 0; i < m_eventAction.Count; i++)
        {
            SC_EventActionManager.Instance.Action(m_eventAction[i]);
        }
        return ResultEndEvent.Nothing;
    }
}
