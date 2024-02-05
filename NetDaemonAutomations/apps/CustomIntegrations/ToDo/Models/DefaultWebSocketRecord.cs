using System.Text.Json.Serialization;
using NetDaemon.Client.HomeAssistant.Model;

namespace HomeAssistantGenerated.apps.CustomIntegrations.ToDo.Models;

public record DefaultWebSocketRecord : CommandMessage
{
    [JsonPropertyName("entity_id")] public string EntityId { get; set; }
}