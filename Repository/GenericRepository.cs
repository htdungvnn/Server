using System.Linq.Expressions;
using System.Text.Json;
using System.Text.Json.Serialization;
using API.DataContext;
using API.Entities;
using API.Logger;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repository;

public class GenericRepository<Entity>:IGenericRepository<Entity> where Entity:BaseEntity
{
    private readonly DbSet<Entity> _entities;
    private readonly ILoggerManager _logger;
    private readonly AppDbContext _context;
    
    public GenericRepository(AppDbContext context,ILoggerManager logger)
    {
        _context = context;
        _entities = context.Set<Entity>();
        _logger = logger;
    }
    public async Task Add(Entity entity)
    {
        try
        {
            if (!await Exist(entity.Id))
            {
                _logger.LogInfo(new LoggerInfo(){Action = LoggerAction.Add, Message = JsonSerializer.Serialize(entity) });
                await _entities.AddAsync(entity);
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }
    }

    public async Task Update(Entity entity)
    {
        try
        {
            if (await Exist(entity.Id))
            {
                _logger.LogInfo(new LoggerInfo(){Action = LoggerAction.Update, Message = JsonSerializer.Serialize(entity) });
                _entities.Update(entity);
            } 
        }
        catch (Exception e)
        {
           _logger.LogError(e.Message);
            throw;
        }
    }

    public async Task Delete(Guid Id)
    {
        try
        {
            if (await Exist(Id))
            {
                _logger.LogInfo(new LoggerInfo(){Action = LoggerAction.Delete, Message = JsonSerializer.Serialize(Id) });
                var entity = await _entities.FindAsync(Id);
                _entities.Remove(entity);
            }
        }
        catch (Exception e)
        {
           _logger.LogError(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Entity>> Find(Expression<Func<Entity, bool>> expression)
    {
        try
        {
            return _entities.Where(expression);
        }
        catch (Exception e)
        {
           _logger.LogError(e.Message);
            throw;
        }
    }

    public async Task<IEnumerable<Entity>> GetAll()
    {
        try
        {
            return await _entities.ToListAsync();
        }
        catch (Exception e)
        {
           _logger.LogError(e.Message);
            throw;
        }
    }

    public async Task<Entity> GetById(Guid Id)
    {
        try
        {
            return await _entities.FindAsync(Id);
        }
        catch (Exception e)
        {
           _logger.LogError(e.Message);
            throw;
        }
    }

    public async Task<PagingResponse<Entity>> Paging(PagingRequest<Entity> request)
    {
        try
        {
            var total=await _entities.CountAsync();
            var entities =  _entities.Where(request.Expression).Skip(request.Page+request.Size).Take(request.Size);
            return new PagingResponse<Entity>()
            {
                Total = total,
                Entities = entities
            };
        }
        catch (Exception e)
        {
           _logger.LogError(e.Message);
            throw;
        }
    }

    public async Task<bool> Exist(Guid Id)
    {
        try
        {
            var exist = await _entities.AnyAsync(x => x.Id == Id);
            if (exist)
            {
                _logger.LogWarn(typeof(Entity).Name+Id.ToString()+"Exist");
            }
            return exist;
        }
        catch (Exception e)
        {
           _logger.LogError(e.Message);
            throw;
        }
    }
     
    public async Task Save()
    {
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            throw;
        }
    }

    private bool disposed = false;

    private async Task Dispose(bool disposing)
    {
        if (!this.disposed)
            
        {
            if (disposing)
            {
                await _context.DisposeAsync();
            }
        }
        this.disposed = true;
    }

    public async void Dispose()
    {
        await Dispose(true);
        GC.SuppressFinalize(this);
    }
}