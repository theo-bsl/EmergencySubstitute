using System;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.FlowStateWidget;

public class SC_RoomPlacementManager : MonoBehaviour
{
    public static SC_RoomPlacementManager Instance;

    [SerializeField]
    private List<SC_EventIcon> m_motorEvent = new List<SC_EventIcon>();

    [SerializeField]
    private List<SC_EventIcon> m_cockpitEvent = new List<SC_EventIcon>();

    [SerializeField]
    private List<SC_EventIcon> m_kitchenEvent = new List<SC_EventIcon>();

    [SerializeField]
    private List<SC_EventIcon> m_infirmaryEvent = new List<SC_EventIcon>();

    [SerializeField]
    private List<SC_EventIcon> m_serverEvent = new List<SC_EventIcon>();

    [SerializeField]
    private GameObject m_eventIconPrefab;

    [SerializeField]
    private Transform m_eventsParent;

    [SerializeField]
    private Transform m_motorRoomWaypoint;

    [SerializeField]
    private Transform m_cockpitRoomWaypoint;

    [SerializeField]
    private Transform m_kitchenRoomWaypoint;

    [SerializeField]
    private Transform m_infirmaryRoomWaypoint;

    [SerializeField]
    private Transform m_serverRoomWaypoint;

    private readonly int m_eventOffset = 50;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        ReorganiseEvent(m_motorEvent, m_motorRoomWaypoint);
        ReorganiseEvent(m_cockpitEvent, m_cockpitRoomWaypoint);
        ReorganiseEvent(m_kitchenEvent, m_kitchenRoomWaypoint);
        ReorganiseEvent(m_infirmaryEvent, m_infirmaryRoomWaypoint);
        ReorganiseEvent(m_serverEvent, m_serverRoomWaypoint);

        SC_EventManager.Instance.NewEvent.AddListener(AddEventToMap);

        SC_EventManager.Instance.DeleteEvent.AddListener(RemoveEventFromMap);
    }

    public void AddEventToMap(SC_Event Event)
    {
        RoomsEnum room = Event.Room;

        GameObject EventIcon = Instantiate(m_eventIconPrefab, m_eventsParent);
        EventIcon.GetComponent<SC_EventIcon>().InitEventIcon(Event);

        switch (room)
        {
            case RoomsEnum.Motor:
                m_motorEvent.Add(EventIcon.GetComponent<SC_EventIcon>());
                ReorganiseEvent(m_motorEvent, m_motorRoomWaypoint);
                break;
            case RoomsEnum.Cockpit:
                m_cockpitEvent.Add(EventIcon.GetComponent<SC_EventIcon>());
                ReorganiseEvent(m_cockpitEvent, m_cockpitRoomWaypoint);
                break;
            case RoomsEnum.Kitchen:
                m_kitchenEvent.Add(EventIcon.GetComponent<SC_EventIcon>());
                ReorganiseEvent(m_kitchenEvent, m_kitchenRoomWaypoint);
                break;
            case RoomsEnum.Infirmary:
                m_infirmaryEvent.Add(EventIcon.GetComponent<SC_EventIcon>());
                ReorganiseEvent(m_infirmaryEvent, m_infirmaryRoomWaypoint);
                break;
            case RoomsEnum.Server:
                m_serverEvent.Add(EventIcon.GetComponent<SC_EventIcon>());
                ReorganiseEvent(m_serverEvent, m_serverRoomWaypoint);
                break;
            default:
                throw new Exception("The Event room " + room.ToString() + " isn't supported");
        }
    }

    private void ReorganiseEvent(List<SC_EventIcon> EventList, Transform Waypoint)
    {
        float offsetPosX = -(m_eventOffset * (EventList.Count - 1) / 2);
        foreach (SC_EventIcon Event in EventList)
        {
            Event.transform.position = Waypoint.position + new Vector3(offsetPosX, 0, 0); 
            offsetPosX += m_eventOffset;
        }
    }

    public void RemoveEventFromMap(SC_Event Event)
    {
        RoomsEnum room = Event.Room;

        switch (room)
        {
            case RoomsEnum.Motor:
                RemoveEvent(Event, m_motorEvent);
                ReorganiseEvent(m_motorEvent, m_motorRoomWaypoint);
                break;
            case RoomsEnum.Cockpit:
                RemoveEvent(Event, m_cockpitEvent);
                ReorganiseEvent(m_cockpitEvent, m_cockpitRoomWaypoint);
                break;
            case RoomsEnum.Kitchen:
                RemoveEvent(Event, m_kitchenEvent);
                ReorganiseEvent(m_kitchenEvent, m_kitchenRoomWaypoint);
                break;
            case RoomsEnum.Infirmary:
                RemoveEvent(Event, m_infirmaryEvent);
                ReorganiseEvent(m_infirmaryEvent, m_infirmaryRoomWaypoint);
                break;
            case RoomsEnum.Server:
                RemoveEvent(Event, m_serverEvent);
                ReorganiseEvent(m_serverEvent, m_serverRoomWaypoint);
                break;
            default:
                throw new Exception("The Event room " + room.ToString() + " isn't supported");
        }
    }

    private void RemoveEvent(SC_Event Event, List<SC_EventIcon> EventList)
    {
        for (int i = 0; i < EventList.Count; i++)
        {
            if (EventList[i].Name == Event.Name)
            {
                EventList.RemoveAt(i);
                break;
            }
        }
    }

}
