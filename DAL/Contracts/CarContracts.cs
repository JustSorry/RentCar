using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IReposCar<T>
    {
        public Task Create(T _object);
        public void Delete(T _object);
        public Task Update(T _object);
        public IEnumerable<T> GetAll();
        //public T GetById(int Id);
    }
}
