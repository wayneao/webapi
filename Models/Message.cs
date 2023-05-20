namespace WebAPI.Models;

public class Message
{
    public long Id { get; set; }
    public string? Username { get; set; }
    public string? MessageContent { get; set; }
    public string? MessageData { get; set; }
    public String? State { get; set; }
}