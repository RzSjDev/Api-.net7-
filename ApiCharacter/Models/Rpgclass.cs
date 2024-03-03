using System.Text.Json.Serialization;
namespace api.net.Models

{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Rpgclass
    {
        Knight = 1,
        mage = 2,
        celeric = 3,
    }
}