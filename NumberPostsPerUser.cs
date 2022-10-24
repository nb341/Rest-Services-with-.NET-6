using System.Text.Json.Serialization;

namespace RestService;

public class NumberPostsPerUser{
    [JsonPropertyName("userId")]
    public int UserId {get; set;}
    [JsonPropertyName("numberOfPosts")]
    public int numberOfPosts {get; set;}
}