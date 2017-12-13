using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WhyBlog.EF.Entity;

namespace WhyBlog.EF.Service
{
    public abstract  class BaseService<T> :IBaseService<T> where T:class
    {
        private readonly BlogContext db;
        public BaseService(BlogContext db)
        {
            this.db = db;
        }



        public virtual T GetEntity(int id)
        {
            
            return db.Find<T>(id);
        }

        public int Add(T model)
        {
            db.Add<T>(model);
            return db.SaveChanges();
        }

        public int Delete(int id)
        {
            var entity = GetEntity(id);
             db.Remove<T>(entity);
            return db.SaveChanges();
        }
    }
}


