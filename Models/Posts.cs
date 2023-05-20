namespace WebAPI.Models;

public class Posts
{
    //帖子id
    public long Id { get; set; }
    public string? Author { get; set; }
    public string? PostTitle { get; set; }
    //文章摘要
    public string? PostKey { get; set; }
    public string? PostContent { get; set; }
    public string? PostData { get; set; }
    public string? PostCategory { get; set; }

}