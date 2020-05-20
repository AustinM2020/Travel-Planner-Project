using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_Planner.Contracts;
using Travel_Planner.Models;

namespace Travel_Planner.Data
{
    public class VacationRepository : RepositoryBase<Vacation>, IVacationRepository
    {
        public VacationRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
        }

        public void CreateVacation(Vacation vacation)
        {
            Create(vacation);
        }

        public async void DeleteVacation(int vacationId)
        {
            var result = await FindByCondition(v => v.Id.Equals(vacationId));
            var vacation = result.SingleOrDefault();
            Delete(vacation);
        }

        public void EditVacation(Vacation vacation)
        {
            Update(vacation);
        }

        public async Task<Vacation> GetVacation(int vacationId)
        {
            var result = await FindByCondition(v => v.Id.Equals(vacationId));
            var vacation = result.SingleOrDefault();
            return vacation;
        }

        public async Task<List<Vacation>> GetVacations(int travelerId)
        {
            var results = await FindByCondition(v => v.TravelerId.Equals(travelerId));
            var vacations = results.ToList();
            return vacations;
        }
    }
}
