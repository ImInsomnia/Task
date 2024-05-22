using Core.Entities;
using System.Linq.Expressions;

namespace Core.DataAccess.Abstract
{
    public interface IRepository<T> where T:BaseEntity,new()
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll(Expression<Func<T,bool>> predicate=null);
        T Get(Expression<Func<T, bool>> expression);
    }
}
