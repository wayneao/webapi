namespace WebAPI.Models;

public class Reply
{
    public long Id { get; set; }
    public string? Username { get; set; }
    public string? ReplyContent { get; set; }
    public string? ReplyData { get; set; }
}