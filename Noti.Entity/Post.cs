namespace Noti.Entities;

public class Post : IEntity
{
    public int Id { get; set; }
    public VirtualProfile PostOwner { get; set; }
    public DateTime PostShareDateTime { get; set; }
    public string PostContent { get; set; }
    public byte[]? PostImage { get; set; }
    public int LikeCount { get; set; }
    public virtual Comment? Comment { get; set; }
}
