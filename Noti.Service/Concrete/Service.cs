using Noti.Data;
using Noti.Data.Concrete;
using Noti.Entities;
using Noti.Service.Abstract;

namespace Noti.Service.Concrete;

public class Service<T> : Repository<T>, IService<T> where T : class, IEntity, new()
{
    public Service(DatabaseContext context) : base(context)
    {
    }
}
