using System.Collections.Generic;

namespace HomeAssistantGenerated.apps.CustomIntegrations.DeviceMonitor.Models;

public class NotificationWithActionsModel
{
    public List<NotificationActions> actions { get; set; }
}

public class NotificationActions
{
    public string action { get; set; }
    public string title { get; set; }
    public string icon { get; set; }
}

public class NotificationResponse
{
    public ActionTask action { get; set; }
}

public enum ActionTask
{
    ConfirmBoot,
    ShutdownHeater
    
}