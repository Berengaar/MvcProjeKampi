using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context context = new Context();
        //Tüm context'e olan bağımlılığı tipe düşürmek için generic tanımlarız.
        DbSet<T> _object;                   

        public GenericRepository()
        {
            //Generic tanımlanan obje context'in tipine göre ayarlandı.
            _object = context.Set<T>();     
        }

        public void Delete(T entity)
        {
            _object.Remove(entity);
            context.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            //SingleOrDefault => Bir dizi veya listede sadece tek bir değer döndürür
            return _object.SingleOrDefault(filter);     
        }

        public void Insert(T entity)
        {
            _object.Add(entity);
            context.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Update(T entity)
        {
            context.SaveChanges();
        }
    }
}
