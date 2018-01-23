using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WhyBlog.Models.Do;

namespace WhyBlog.EF.Dao
{
    public abstract class BaseDao<T> : IBaseDao<T> where T : BaseEntity
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

    

        public int Add(T model)
        {
            model.CreateTime = DateTime.Now;
            db.Add<T>(model);
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            var entity = Get(id);
             db.Remove<T>(entity);
            return db.SaveChanges();
        }

        public virtual IEnumerable<T> Get(Expression<Func<T,bool>> expression)
        {
            return db.Set<T>().Where(expression).Where(p=>p.IsDeleted!=true);
        }

        public virtual int Update(T oldEntity ,T newEntity)
        {
            newEntity.ModifyTime = DateTime.Now;
            db.Entry(oldEntity).CurrentValues.SetValues(newEntity);
            return db.SaveChanges();
        }

        public virtual int Update(IEnumerable<T> oldLst,IEnumerable<T>newLst)
        {
            foreach(var item in newLst)
            {
                item.ModifyTime = DateTime.Now;
            }
            db.Entry(oldLst).CurrentValues.SetValues(newLst);
            return db.SaveChanges();
        }
    }
}


