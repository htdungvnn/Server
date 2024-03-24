using API.Entities;
using API.Repository;
using API.Services;

namespace API.UOW;

public interface IUnitOfWork
{
    public ITodoService TodoService { get; }
}