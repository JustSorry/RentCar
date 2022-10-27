using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DAL.Contracts
{
	public interface IReposUser <T>
	{
        public Task<IdentityResult> Create(T _object, string password);
        public void Delete(T _object);
        public Task Update(T _object);
        public IEnumerable<T> GetAll();
        //public T GetById(int Id);
    }
}
