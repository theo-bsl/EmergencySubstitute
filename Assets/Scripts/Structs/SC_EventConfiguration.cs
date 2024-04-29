using System;
using System.Collections.Generic;

[Serializable]
public struct EventConfiguration
{
    public SC_Event SC_Event;
    public List<EventAction> EventActions;
}
