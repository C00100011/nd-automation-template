using System.Collections.Generic;

namespace HomeAssistantGenerated.apps.CustomIntegrations.ToDo.Models;

public class Item
{
    public string summary { get; set; }
    public string uid { get; set; }
    public string status { get; set; }
}

public class ToDoModel
{
    public List<Item> items { get; set; }
}