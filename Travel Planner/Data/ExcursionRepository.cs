using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_Planner.Contracts;
using Travel_Planner.Models;

namespace Travel_Planner.Data
{
    public class ExcursionRepository : RepositoryBase<Excursion>, IExcursionRepository
    {
        public ExcursionRepository(ApplicationDbContext applicationDbContext)
            : base(applicationDbContext)
        {
        }

        public void CreateExcursion(Excursion excursion)
        {
            Create(excursion);
        }

        public async void DeleteExcursion(int ExcursionId)
        {
            var result = await FindByCondition(e => e.Id.Equals(ExcursionId));
            var excursion = result.SingleOrDefault();
            Delete(excursion);
        }

        public void EditExcursion(Excursion excursion)
        {
            Update(excursion);
        }

        public async Task<Excursion> GetExcursion(int excursionId)
        {
            var result = await FindByCondition(e => e.Id.Equals(excursionId));
            var excursion = result.SingleOrDefault();
            return excursion;
        }

        public async Task<List<Excursion>> GetExcursions(int vacationId)
        {
            var results = await FindByCondition(e => e.VacationId.Equals(vacationId));
            var excursions = results.ToList();
            return excursions;
        }
    }
}
