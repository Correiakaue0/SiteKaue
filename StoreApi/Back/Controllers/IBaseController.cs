using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Back.Controllers
{
    public interface IBaseController<T> where T : class
    {
        public T Create(T u);
        public List<T> Get();
        public T GetForId(int id);
        public T Edit(int id, T New);
        public bool Delete(int id);
    }
}