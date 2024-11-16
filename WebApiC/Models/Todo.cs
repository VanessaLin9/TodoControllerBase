using System.Text.Json.Serialization;

namespace WebApiC.Models;


public record Todo(int Id, string? Title, DateOnly? DueBy = null, bool IsComplete = false);

[JsonSerializable(typeof(Todo[]))]

internal partial class AppJsonSerializerContext : JsonSerializerContext
{

}
