namespace WebAPI.Models;

public class News
{
    public long Id { get; set; }
    public string? Title { get; set; }
    //新闻文章内容
    public string? Content { get; set; }
    public string? CreateData { get; set; }
    //新闻分类
    public string? Category { get; set; }




}