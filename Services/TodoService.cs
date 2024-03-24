using API.DataContext;
using API.Entities;
using API.Logger;
using API.Repository;

namespace API.Services;

public class TodoService:GenericRepository<Todo>,ITodoService
{
    public TodoService(AppDbContext context, ILoggerManager logger) : base(context, logger)
    {
    }
}