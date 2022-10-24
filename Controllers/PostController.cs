using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace RestService.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    static readonly HttpClient client = new HttpClient();

    private readonly ILogger<PostController> _logger;

    public PostController(ILogger<PostController> logger)
    {
        _logger = logger;
    }


[HttpGet]
public async Task<ActionResult<List<Post>>> Get()
{
    try
    {
      

        using HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        // Above three lines can be replaced with new helper method belyow
        // string responseBody = await client.GetStringAsync(uri);
                var posts = JsonSerializer.Deserialize<List<Post>>(responseBody);
                PostCalculations p = new PostCalculations(posts);
                var s = p.postPerUsers();
                //var a = new NumberPostsPerUser{UserId=1, numberOfPosts=s.GetValueOrDefault(1)};
                return Ok(s);
            
          
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine("\nException Caught!");
        Console.WriteLine("Message :{0} ", e.Message);
        return BadRequest();
    }
    
}
}
