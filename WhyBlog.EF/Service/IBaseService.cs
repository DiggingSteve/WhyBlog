using System;
using System.Collections.Generic;
using System.Text;

namespace WhyBlog.EF.Service
{
  public  interface IBaseService<T>
    {

         T GetEntity(int id);

        int Add(T model);

        int Delete(int id);
    }
}
