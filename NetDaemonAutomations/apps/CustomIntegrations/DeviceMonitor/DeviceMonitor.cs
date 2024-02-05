using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using HomeAssistantGenerated.apps.CustomIntegrations.DeviceMonitor.Models;
using NetDaemon.Client;
using Newtonsoft.Json;

namespace HomeAssistantGenerated.apps.CustomIntegrations.DeviceMonitor;

[NetDaemonApp]
public class DeviceMonitor
{
    public DeviceMonitor(IHaContext ha, IHomeAssistantRunner runner)
    {
        var entity = new Entities(ha);
        var services = new Services(ha);
        var acties = new List<NotificationActions>();
        acties.Add(new NotificationActions()
        {
            action = ActionTask.ConfirmBoot.ToString(),
            title = "Bevestig deployment",
            icon = "sfsymbols:bell"
        });
        services.Notify.MobileAppIphoneVanGideon(new NotifyMobileAppIphoneVanGideonParameters()
        {
            Title = "SkyNet",
            Message = "Daemon has been activated, new",
            Data = new NotificationWithActionsModel()
            {
                actions = acties
            }

        });
        ha.Events.Where(t => t.EventType == "mobile_app_notification_action").Subscribe(_ =>
        {
            NotificationResponse rest = JsonConvert.DeserializeObject<NotificationResponse>(_.DataElement.Value.ToString());
            switch (rest.action)
            {
                case ActionTask.ConfirmBoot:
                {
                    entity.InputBoolean.ReloadNewNetdaemon.TurnOff();
                    services.Notify.MobileAppIphoneVanGideon(new NotifyMobileAppIphoneVanGideonParameters()
                    {
                        Title = "SkyNet",
                        Message = "Thanks for confirming, your new daemon code is live!"
                    });
                    break;
                }
                case ActionTask.ShutdownHeater:
                {
                    break;
                }
            }
            
        });      
        entity.Sensor.CentraleVerwarmingTemperature.StateChanges().Where(t => t.New.State > 21.0)
            .Subscribe(_ => services.Notify.MobileAppIphoneVanGideon(new NotifyMobileAppIphoneVanGideonParameters()
            {
                Title = "SkyNet - Meldingen",
                Message = $"Binnen tempratuur hoger dan 20.0 graden ({_.New.State.Value})"
            }));
        
        entity.BinarySensor.CentraleVerwarmingConnectiviteit.StateChanges()
            .Subscribe(_ => services.Notify.MobileAppIphoneVanGideon(new NotifyMobileAppIphoneVanGideonParameters()
            {
                Title = "SkyNet - Meldingen",
                Message = "Er zijn problemen met de verwarming.",
                
            }));
    }
}