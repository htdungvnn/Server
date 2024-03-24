using System.Linq.Expressions;
using API.Entities;
using API.Models;

namespace API.Repository;

public interface IGenericRepository<Entity> where Entity:BaseEntity
{
    Task Add(Entity entity);
    Task Update(Entity entity);
    Task Delete(Guid Id);
    Task<IEnumerable<Entity>> Find(Expression<Func<Entity,bool>> expression);
    Task<IEnumerable<Entity>> GetAll();
    Task<Entity> GetById(Guid Id);
    Task<PagingResponse<Entity>> Paging(PagingRequest<Entity> request);
    Task<bool> Exist(Guid Id);
    Task Save();
}