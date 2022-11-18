using BAL.Interfaces;
using DAL.Contracts;
using DAL.Models;

namespace BAL.Services
{
    public class CompareService : ICompareService
    {
        private IReposCompare _reposCompare;
        private IReposUser _reposUser;
        public CompareService(IReposCompare reposCompare, IReposUser reposUser)
        {
            _reposCompare = reposCompare;
            _reposUser = reposUser;
        }

        public async Task Update (Compare compare)
        {
            await _reposCompare.Update(compare);
        }
        public async Task<string> AddToCompare(User user, Car car)
        {
            if(user.UserCompare.CompareCar1ID == null && user.UserCompare.CompareCar2ID == null)
            {
                user.UserCompare = new Compare { UserId = user.Id, CompareCar1ID = car.Id, CompareCar2ID = null };
                await _reposUser.Update(user);
				return "success";
            }
            if(user.UserCompare.CompareCar1ID == car.Id || user.UserCompare.CompareCar2ID == car.Id) {return "car-act-in-com";}
            else
            {
                if(user.UserCompare.CompareCar1ID == null) { user.UserCompare.CompareCar1ID = car.Id; }
                if(user.UserCompare.CompareCar2ID == null) { user.UserCompare.CompareCar2ID = car.Id; }
                await _reposUser.Update(user);
                return "success";
            }
        }

        public async Task<string> DeleteFromCompare(User user, Car car)
        {
			if (user.UserCompare.CompareCar1ID == null & user.UserCompare.CompareCar2ID == null) { return "com-is-empty";}
            else
            {
                if(user.UserCompare.CompareCar1ID == car.Id) 
                {
                    user.UserCompare.CompareCar1ID = null;
                }
                if(user.UserCompare.CompareCar2ID == car.Id) 
                {
                    user.UserCompare.CompareCar2ID = null; 
                }
                await _reposUser.Update(user);
                return "success";
            }
        }

        public async Task DeleteCompare(User user)
        {
            user.UserCompare = null;
            await _reposCompare.DeleteCompare(user.UserCompare);
            await _reposUser.Update(user);
        }

        public IEnumerable<Compare> GetAll()
        {
            return _reposCompare.GetAll();
        }
    }
}
