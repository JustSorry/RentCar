using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Contracts
{
    public interface IReposCar
    {
        Task Create(Car car);
        void Delete(Car car);
        Task Update(Car car);
        IEnumerable<Car> GetAll();
        bool CheckCar(string req, Car car);
        Task<Car> GetCar(int id);
    }
}