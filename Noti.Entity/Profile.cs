namespace Noti.Entities;

public class Profile : IEntity
{
    public int Id { get; set; }
    public string DisplayName { get; set; }
    public string Name { get; set; }
    public virtual VirtualProfile VirtualProfile { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string HashedPassword { get; set; }
    public byte[] ProfilePhoto { get; set; }
    public virtual VirtualProfile Followers { get; set; }
    public virtual VirtualProfile Following { get; set; }
    public virtual Post Posts { get; set; }
}
