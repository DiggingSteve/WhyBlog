using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace WhyBlog.EF.Dao
{
  public  interface IBaseDao<T>
    {
        /// <summary>
        /// 获取单个实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
         T Get(int id);

 
        IEnumerable<T> Get(Expression<Func<T, bool>> expression);

        int Update(T entity);
        int Update(IEnumerable<T> list);

        bool Add(T model);

        int Delete(int id);
    }
}
