using API.DataContext;
using API.Entities;
using API.Logger;
using API.Repository;
using API.Services;

namespace API.UOW;

public class UnitOfWork:IUnitOfWork
{
    private readonly AppDbContext _context;
    private readonly ILoggerManager _logger;
        public ITodoService TodoService { get; }

    public UnitOfWork(AppDbContext context,
        ITodoService todoService)
    {
        _context = context;
        TodoService = todoService;
    }
}