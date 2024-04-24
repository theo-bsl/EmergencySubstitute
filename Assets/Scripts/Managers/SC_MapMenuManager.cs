using System.Collections.Generic;
using UnityEngine;

public class SC_MapMenuManager : MonoBehaviour
{
    [SerializeField]
    private List<SC_CharacterIcon> m_characters = new List<SC_CharacterIcon>();

    [SerializeField]
    private List<SC_UIEvent> m_events = new List<SC_UIEvent>();

    [SerializeField]
    private GameObject m_eventUIPrefab;

    [SerializeField]
    private GameObject m_eventsParent;

    [SerializeField]
    private RectTransform m_firstEventWaypoint;

    private readonly int m_viewportOffset = -203;

    private void Start()
    {
        for (int i = 0; i < m_characters.Count; i++)
        {
            SO_Character Character = SC_CharacterManager.Instance.Characters[i];
            m_characters[i].InitCharacterIcon(Character);
        }

        SC_EventManager.Instance.NewEvent.AddListener(AddEventToUI);

        SC_EventManager.Instance.DeleteEvent.AddListener(RemoveEventFromUI);

        ReorganiseEvent();
    }

    public void AddEventToUI(SC_Event Event)
    {
        GameObject NewEvent = Instantiate(m_eventUIPrefab, m_firstEventWaypoint.parent.transform);

        NewEvent.GetComponent<SC_UIEvent>().InitEventIcon(Event);

        NewEvent.transform.localPosition += new Vector3(0, (m_events.Count - 1) * m_viewportOffset, 0);
        m_eventsParent.GetComponent<RectTransform>().offsetMin += new Vector2(0, m_viewportOffset);

        m_events.Add(NewEvent.GetComponent<SC_UIEvent>());
    }

    public void RemoveEventFromUI(SC_Event Event)
    {
        for (int i = 0; i < m_events.Count; i--)
        {
            if (Event.Name == m_events[i].Name)
            {
                m_events.Remove(m_events[i]);
                break;
            }
        }
        ReorganiseEvent();
    }

    private void ReorganiseEvent()
    {
        //Set the bottom of the Event Parent (for the scroll)
        if (m_events.Count <= 4)
        {
            m_eventsParent.GetComponent<RectTransform>().offsetMin = new Vector2(m_eventsParent.GetComponent<RectTransform>().offsetMin.x, 0);
        }
        else
        {
            m_eventsParent.GetComponent<RectTransform>().offsetMin = new Vector2(m_eventsParent.GetComponent<RectTransform>().offsetMin.x, m_viewportOffset * (m_events.Count - 4));
        }

        //Reorganise the events in the scrollview
        for (int i = 0;  i < m_events.Count; i++)
        {
            Transform Event = m_eventsParent.transform.GetChild(i+1);
            Event.localPosition = m_firstEventWaypoint.localPosition + new Vector3(0, i * m_viewportOffset, 0);
        }
    }
}
