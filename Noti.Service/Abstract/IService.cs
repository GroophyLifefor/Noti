using Noti.Data.Abstract;
using Noti.Entities;

namespace Noti.Service.Abstract;

public interface IService<T> : IRepository<T> where T : class, IEntity, new()
{

}
