using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_Planner.Models;

namespace Travel_Planner.Contracts
{
    public interface IFlightRepository : IRepositoryBase<Flight>
    {
        Task<List<Flight>> GetFlights(int vacationId);
        Task<Flight> GetFlight(int flightId);
        void CreateFlight(Flight flight);
        void EditFlight(Flight flight);
        void DeleteFlight(int flightId);
    }
}
