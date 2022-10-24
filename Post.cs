using System.Text.Json.Serialization;

namespace RestService;

public class Post
{
    [JsonPropertyName("userId")]
    public int UserId {get; set;}
    [JsonPropertyName("id")]
    public int Id {get; set;}
     [JsonPropertyName("title")]
    public string Title { get; set; } =String.Empty;
    [JsonPropertyName("body")]
    public string Body { get; set; }=String.Empty;
}
