using AddressBook.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook.Shared.Repository
{
    public interface IRepository<T> where T : class, new()
    {
        GetOneResult<T> Add(T t);
        Task<GetOneResult<T>> AddAsync(T t);
        Result Delete(T entity);
        Result DeleteById(int id);
        Task<Result> DeleteAsync(T entity);
        GetOneResult<T> Find(Expression<Func<T, bool>> match);
        Task<GetOneResult<T>> FindAsync(Expression<Func<T, bool>> match);
        GetManyResult<T> FindAll(Expression<Func<T, bool>> match);
        Task<GetManyResult<T>> FindAllAsync(Expression<Func<T, bool>> match);
        GetOneResult<T> Get(int id);
        Task<GetOneResult<T>> GetAsync(int id);
        GetManyResult<T> GetAll();
        Task<GetManyResult<T>> GetAllAsync();
        void Save();
        Task<int> SaveAsync();
        GetOneResult<T> Update(T t, object key);
        GetOneResult<T> UpdateById(T t, int id);
        Task<GetOneResult<T>> UpdateAsync(T t);
    }
}
