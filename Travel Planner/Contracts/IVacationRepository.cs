using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_Planner.Models;

namespace Travel_Planner.Contracts
{
    public interface IVacationRepository : IRepositoryBase<Vacation>
    {
        Task<List<Vacation>> GetVacations(int travelerId);
        Task<Vacation> GetVacation(int vacationId);
        void CreateVacation(Vacation vacation);
        void EditVacation(Vacation vacation);
        void DeleteVacation(int vacationId);
    }
}
