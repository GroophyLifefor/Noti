namespace Noti.Entities;

public class VirtualProfile : IEntity
{
    public int Id { get; set; }
    public byte[]? ProfilePhoto { get; set; }
    public string DisplayName { get; set; }
    public string Name { get; set; }
}
