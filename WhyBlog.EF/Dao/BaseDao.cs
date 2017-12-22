using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace WhyBlog.EF.Dao
{
    public abstract class BaseDao<T> : IBaseDao<T> where T : class
    {
        private readonly BlogContext db;
        public BaseDao(BlogContext db)
        {
            this.db = db;
        }



        public virtual T Get(int id)
        {

            return db.Find<T>(id);
        }

    

        public bool Add(T model)
        {
            db.Add<T>(model);
            return db.SaveChanges()>0?true:false;
        }

        public int Delete(int id)
        {
            var entity = Get(id);
             db.Remove<T>(entity);
            return db.SaveChanges();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T,bool>> expression)
        {
            return db.Set<T>().Where(expression);
        }

        public virtual int Update(T entity)
        {

             db.Set<T>().Update(entity);
            return db.SaveChanges();
        }

        public virtual int Update(IEnumerable<T> list)
        {
            db.Set<T>().UpdateRange(list);
            return db.SaveChanges();
        }
    }
}


