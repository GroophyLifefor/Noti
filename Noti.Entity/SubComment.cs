namespace Noti.Entities;

public class SubComment : IEntity
{
    public int Id { get; set; }
    public virtual VirtualProfile VirtualProfile { get; set; }
    public string CommentMessage { get; set; }
    public int LikeCount { get; set; }
}
