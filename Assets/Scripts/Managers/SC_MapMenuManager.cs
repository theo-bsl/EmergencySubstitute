using System.Collections.Generic;
using UnityEngine;

public class SC_MapMenuManager : MonoBehaviour
{
    [SerializeField]
    private List<SC_UIEvent> m_events = new List<SC_UIEvent>();

    [SerializeField]
    private GameObject m_eventUIPrefab;

    [SerializeField]
    private GameObject m_scrollViewContainer;

    [SerializeField]
    private RectTransform m_firstEventWaypoint;

    private readonly int m_viewportOffset = -203;

    private void Start()
    {
        SC_EventManager.Instance.NewEvent.AddListener(AddEventToUI);

        SC_EventManager.Instance.DeleteEvent.AddListener(RemoveEventFromUI);

        ReorganiseEvent();
    }

    public void AddEventToUI(SC_Event Event)
    {
        GameObject NewEvent = Instantiate(m_eventUIPrefab, m_firstEventWaypoint.parent.transform);

        NewEvent.GetComponent<SC_UIEvent>().InitEventIcon(Event);

        m_events.Add(NewEvent.GetComponent<SC_UIEvent>());

        ReorganiseEvent();
    }

    public void RemoveEventFromUI(SC_Event Event)
    {
        for (int i = 0; i < m_events.Count; i++)
        {
            if (Event.Name == m_events[i].Name)
            {
                Destroy(m_events[i].gameObject);
                m_events.RemoveAt(i);
                break;
            }
        }
        ReorganiseEvent();
    }

    private void ReorganiseEvent()
    {
        //Set the bottom of the Event Parent (for the scroll)
        float bottomScrollViewContainer = m_events.Count <= 4 ? 0 : m_viewportOffset * (m_events.Count - 4);
        m_scrollViewContainer.GetComponent<RectTransform>().offsetMin = new Vector2(m_scrollViewContainer.GetComponent<RectTransform>().offsetMin.x, bottomScrollViewContainer);

        //Reorganise the events in the scrollview
        for (int i = 0; i < m_events.Count; i++)
        {
            Transform Event = m_events[i].gameObject.transform;
            Event.localPosition = m_firstEventWaypoint.localPosition + new Vector3(0, i * m_viewportOffset, 0);
        }
    }
}