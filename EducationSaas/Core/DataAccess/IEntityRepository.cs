using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    /// <summary>
    /// </summary>
    /// <typeparam name="T">
    /// t refarans tipinde olmali Ientityden 
    /// implemente edilis newlenebilir 
    /// her sey gonderilebilir buraya</typeparam>
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        void Add(T entity);
        void update(T entity);
        void Delete(T entity);

    }
}
