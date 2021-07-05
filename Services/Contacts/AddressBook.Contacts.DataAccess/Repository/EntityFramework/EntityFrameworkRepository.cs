using AddressBook.Shared.Models;
using AddressBook.Shared.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Contacts.DataAccess.Repository.EntityFramework
{
    public class EntityFrameworkRepository<TContext, TEntity> : IRepository<TEntity>
       where TEntity : class, new()
       where TContext : DbContext
    {
        TContext _context;
        DbSet<TEntity> _dbSet;
        public EntityFrameworkRepository(TContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public GetManyResult<TEntity> GetAll()
        {
            var result = new GetManyResult<TEntity>();
            try
            {
                if (_dbSet is IQueryable<TEntity> entity)
                {
                    result.Result = entity;
                }

                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"GetAll Exception getting one {typeof(TEntity).Name}, Message: {ex.Message}";
                return result;
            }
        }
        public virtual async Task<GetManyResult<TEntity>> GetAllAsync()
        {
            var result = new GetManyResult<TEntity>();
            try
            {
                var entity = await _dbSet.ToListAsync();
                if (entity != null)
                {
                    result.Result = entity;
                }

                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"GetAllAsyn Exception getting one {typeof(TEntity).Name}, Message: {ex.Message}";
                return result;
            }
        }
        public virtual GetOneResult<TEntity> Get(int id)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                var entity = _dbSet.Find(id);
                if (entity != null)
                {
                    result.Entity = entity;
                }

                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Get Exception getting one {typeof(TEntity).Name}, Message: {ex.Message}";
                return result;
            }
        }
        public virtual async Task<GetOneResult<TEntity>> GetAsync(int id)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity != null)
                {
                    result.Entity = entity;
                }

                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"GetOne Exception getting one {typeof(TEntity).Name}, Message: {ex.Message}";
                return result;
            }
        }
        public virtual GetOneResult<TEntity> Add(TEntity t)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                _dbSet.Add(t);
                _context.SaveChanges();
                result.Entity = t;
                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Add Exception getting one {typeof(TEntity).Name}, Message: {ex.Message}";
                return result;
            }
        }
        public virtual async Task<GetOneResult<TEntity>> AddAsync(TEntity t)
        {
            var result = new GetOneResult<TEntity>();
            try
            {

                var model = _context.Entry(t);
                model.State = EntityState.Added;
                await _context.SaveChangesAsync();
                result.Entity = t;
                return result;


            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"AddAsyn Exception getting one {typeof(TEntity).Name}, Message: {ex.Message}";
                return result;
            }
        }
        public virtual GetOneResult<TEntity> Find(Expression<Func<TEntity, bool>> match)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                var entity = _dbSet.FirstOrDefault(match);
                if (entity != null)
                {
                    result.Entity = entity;
                    return result;
                }
                else
                {
                    result.Entity = null;
                    return result;
                }

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Find Exception getting one {typeof(TEntity).Name}, Message: {ex.Message}";
                return result;
            }
        }
        public virtual async Task<GetOneResult<TEntity>> FindAsync(Expression<Func<TEntity, bool>> match)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                var entity = await _dbSet.FirstOrDefaultAsync(match);
                if (entity != null)
                {
                    result.Entity = entity;
                    return result;
                }
                else
                {

                    result.Entity = null;
                    return result;
                }

            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"FindAsync Exception getting one {typeof(TEntity).Name}, Message: {ex.Message}";
                return result;
            }
        }
        public GetManyResult<TEntity> FindAll(Expression<Func<TEntity, bool>> match)
        {
            var result = new GetManyResult<TEntity>();
            try
            {
                var entity = _dbSet.Where(match).ToList();
                result.Result = entity;

                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"FindAll Exception getting one {typeof(TEntity).Name}, Message: {ex.Message}";
                return result;
            }
        }
        public async Task<GetManyResult<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> match)
        {
            var result = new GetManyResult<TEntity>();
            try
            {
                var entity = await _dbSet.Where(match).ToListAsync();
                if (entity != null)
                {
                    result.Result = entity;
                }

                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"FindAllAsync Exception getting one {typeof(TEntity).Name}, Message: {ex.Message}";
                return result;
            }
        }
        public virtual Result DeleteById(int id)
        {
            var result = new Result();
            try
            {
                var entity = Get(id);
                _dbSet.Remove(entity.Entity);
                _context.SaveChanges();

                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Delete Exception deleting one {typeof(TEntity).Name}, Message: {ex.Message}";
                return result;
            }
        }
        public virtual Result Delete(TEntity entity)
        {
            var result = new Result();
            try
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();

                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Delete Exception deleting one {typeof(TEntity).Name}, Message: {ex.Message}";
                return result;
            }
        }
        public virtual async Task<Result> DeleteAsync(TEntity entity)
        {
            var result = new Result();
            try
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();

                return result;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Delete Exception deleting one {typeof(TEntity).Name}, Message: {ex.Message}";
                return result;
            }
        }
        public virtual GetOneResult<TEntity> Update(TEntity t, object key)
        {
            if (t == null)
                return null;

            var result = new GetOneResult<TEntity>();
            try
            {
                var exist = _dbSet.Find(key);
                if (exist != null)
                {
                    _context.Entry(exist).CurrentValues.SetValues(t);
                    _context.SaveChanges();
                }

                result.Entity = exist;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = $"Update Exception getting one {typeof(TEntity).Name}, Message: {ex.Message}";

            }

            return result;
        }
        public virtual GetOneResult<TEntity> UpdateById(TEntity t, int id)
        {
            if (t == null)
                return null;

            var response = new GetOneResult<TEntity>();
            try
            {
                var model = _dbSet.Find(id);

                if (model == null)
                    return null;

                var result = _context.Entry(model);
                result.State = EntityState.Modified;
                _context.SaveChanges();
                response.Success = true;
                response.Entity = result.Entity;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Update Exception getting one {typeof(TEntity).Name}, Message: {ex.Message}";
            }
            return response;
        }
        public virtual async Task<GetOneResult<TEntity>> UpdateAsync(TEntity model)
        {
            var response = new GetOneResult<TEntity>();
            try
            {
                if (model == null)
                    return null;
                var result = _context.Entry(model);

                result.State = EntityState.Modified;
                await _context.SaveChangesAsync();
                response.Success = true;
                response.Entity = result.Entity;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = $"Update Exception getting one {typeof(TEntity).Name}, Message: {ex.Message}";
            }
            return response;
        }
        public virtual void Save()
        {
            _context.SaveChanges();
        }
        public virtual async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
        
    }
}
