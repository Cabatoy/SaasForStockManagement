using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class IEFEntityRepositoryBase<Tentity, Tcontext> : IEntityRepository<Tentity>
        where Tentity : class, IEntity, new()
        where Tcontext : DbContext, new()
    {
        public void Add(Tentity entity)
        {
            //unit of work kendisinde dahil
            using (var context = new Tcontext())
            {
                //gonderilen entity i context e abone ettik.ister update ister delete ne yapacaksan 
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Tentity entity)
        {
            using (var context = new Tcontext())
            {
                //gonderilen entity i context e abone ettik.ister update ister delete ne yapacaksan 
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public void update(Tentity entity)
        {
            using (var context = new Tcontext())
            {
                //gonderilen entity i context e abone ettik.ister update ister delete ne yapacaksan 
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public Tentity Get(Expression<Func<Tentity, bool>> filter)
        {
            using (var context = new Tcontext())
            {
                return context.Set<Tentity>().SingleOrDefault(filter);
            }
        }

        public List<Tentity> GetList(Expression<Func<Tentity, bool>> filter = null)
        {
            using (var context = new Tcontext())
            {
                return filter == null ? context.Set<Tentity>().ToList() : context.Set<Tentity>().Where(filter).ToList();
            }
        }


    }
}
