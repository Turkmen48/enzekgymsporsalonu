using Microsoft.EntityFrameworkCore;
using sporsalonutakipsistemi.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace sporsalonutakipsistemi.Repositories
{
    public interface IEntity
    {
        int Id { get; set; }
    }
    public class GenericRepository<T> where T : class, IEntity, new()
    {
        Context c = new Context();




        public List<T> TList()
        {
            return c.Set<T>().ToList();
        }

        public void TAdd(T t)
        {
            c.Set<T>().Add(t);
            c.SaveChanges();
        }

        public void TRemove(T t)
        {
            c.Set<T>().Remove(t);
            c.SaveChanges();
        }

        public void TUpdate(T t)
        {
            c.Set<T>().Update(t);
            c.SaveChanges();
        }

        public void TSaveChanges()
        {
            c.SaveChanges();

        }

        public T TGetInc(int id, string includeProperties = "")
        {
            IQueryable<T> query = c.Set<T>();

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            return query.FirstOrDefault(x => x.Id == id);
        }

        public T TGet(int id)
        {
            return c.Set<T>().Find(id);
        }
        public T TGet(Func<T, bool> predicate)
        {
            return c.Set<T>().SingleOrDefault(predicate);
        }


        public List<T> TList(params string[] includes)
        {
            IQueryable<T> query = c.Set<T>();

            // Her bir tablo adını dahil edin
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            return query.ToList();
        }

        public async Task<IEnumerable<T>> GetFilteredDataAsync(Expression<Func<T, bool>> filterExpression)
        {
            return await c.Set<T>().Where(filterExpression).ToListAsync();
        }

    }
}
