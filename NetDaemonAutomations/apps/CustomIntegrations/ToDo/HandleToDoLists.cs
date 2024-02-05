using System.Threading;
using System.Threading.Tasks;
using HomeAssistantGenerated.apps.CustomIntegrations.ToDo.Models;
using NetDaemon.Client;
using Newtonsoft.Json;

namespace HomeAssistantGenerated.apps.CustomIntegrations.ToDo;


public class HandleToDoLists
{
    public HandleToDoLists(IHaContext ha, IHomeAssistantRunner runner)
    {
        var entitiesOfHa = new Entities(ha);
        var result = GetToDoList(entitiesOfHa.Todo.HuishoudelijkeTaken, runner).Result;
        foreach (var listitem in result.items)
        {
            Console.WriteLine(@$"{listitem.summary} -- {listitem.status} -- {listitem.uid}");
        }
    }
    private async Task<ToDoModel> GetToDoList(TodoEntity entity, IHomeAssistantRunner runner)
    {
        var command = new DefaultWebSocketRecord()
        {
            EntityId = entity.EntityId,
            Id = 30,
            Type = "todo/item/list"
        };
        var response = runner.CurrentConnection?.SendCommandAndReturnResponseRawAsync(command, CancellationToken.None)
            .Result ?? null;
        ToDoModel rest = JsonConvert.DeserializeObject<ToDoModel>(response.Value.ToString());
        return rest;
    }
}