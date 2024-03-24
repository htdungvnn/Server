using System.Linq.Expressions;
using API.Entities;

namespace API.Models;

public class PagingRequest<Entity> where Entity:BaseEntity
{
    public int Page { get; set; }
    public int Size { get; set; }
    public Expression<Func<Entity,bool>> Expression { get; set; }
}

public class PagingResponse<Entity> where Entity : BaseEntity
{
    public int Total { get; set; }
    public IEnumerable<Entity> Entities { get; set; }
}