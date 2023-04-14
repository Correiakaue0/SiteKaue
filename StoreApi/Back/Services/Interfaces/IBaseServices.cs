using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Back.Services.Interfaces
{
    public interface IBaseServices<T> where T : class
    {
        public T Create(T u);
        public List<T> Get();
        public T GetForId(int id);
        public T Edit(int id, T New);
        public bool Delete(int id);
    }
}