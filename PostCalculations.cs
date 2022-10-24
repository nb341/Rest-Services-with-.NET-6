namespace RestService;
public class PostCalculations{
    private List<Post> posts;
    private List<NumberPostsPerUser> num = new List<NumberPostsPerUser>();
    private Dictionary<int, int> userMap = new Dictionary<int, int>();

    public PostCalculations(List<Post> posts){
        this.posts = posts;
        foreach(var p in posts){
            if(!userMap.ContainsKey(p.UserId)){
                userMap.Add(p.UserId, 0);
            }else{
                userMap[p.UserId]+=1;
            }
        }
    }

    public List<NumberPostsPerUser> postPerUsers(){
        //Dictionary<int, int> users = new Dictionary<int, int>();
        //  foreach(var post in posts){
        //     if(users.ContainsKey(post.UserId)){
        //        users[post.UserId]+=1;
                
        //     }else{
        //          users.Add(post.UserId, 0);
        //     }
               
        //  }
        //  foreach(KeyValuePair<int,int> p in users){
        //       Console.WriteLine(p.Key+" "+p.Value);
        //  }
        foreach(KeyValuePair<int,int> p in userMap){
             num.Add(new NumberPostsPerUser{UserId=p.Key, numberOfPosts=p.Value});
        }
        return num;
       
    }

    public void printPosts(){
                foreach(var post in posts){
                    Console.WriteLine(post?.Id);
                }
    }
}