using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_Planner.Models;

namespace Travel_Planner.Contracts
{
    public interface ITravelerRepository : IRepositoryBase<Traveler>
    {
        Task<Traveler> GetTraveler(int? travelerId);
        Task<Traveler> GetTraveler(string userId);
        void CreateTraveler(Traveler traveler);
        void EditTraveler(Traveler traveler);
        void DeleteTraveler(int? travelerId);
    }
}
