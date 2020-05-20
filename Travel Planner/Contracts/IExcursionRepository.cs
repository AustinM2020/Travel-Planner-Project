using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_Planner.Models;

namespace Travel_Planner.Contracts
{
    public interface IExcursionRepository : IRepositoryBase<Excursion>
    {
        Task<List<Excursion>> GetExcursions(int vacationId);
        Task<Excursion> GetExcursion(int excursionId);
        void CreateExcursion(Excursion excursion);
        void EditExcursion(Excursion excursion);
        void DeleteExcursion(int ExcursionId);
    }
}
