using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_Planner.Contracts;
using Travel_Planner.Models;

namespace Travel_Planner.Data
{
    public class FlightRepository : RepositoryBase<Flight>, IFlightRepository
    {
        public FlightRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
        }

        public void CreateFlight(Flight flight)
        {
            Create(flight);
        }

        public async void DeleteFlight(int flightId)
        {
            var result = await FindByCondition(v => v.Id.Equals(flightId));
            var flight = result.SingleOrDefault();
            Delete(flight);
        }

        public void EditFlight(Flight flight)
        {
            Update(flight);
        }

        public async Task<Flight> GetFlight(int flightId)
        {
            var result = await FindByCondition(v => v.Id.Equals(flightId));
            var flight = result.SingleOrDefault();
            return flight;
        }

        public async Task<List<Flight>> GetFlights(int vacationId)
        {
            var results = await FindByCondition(v => v.VacationId.Equals(vacationId));
            var flights = results.ToList();
            return flights;
        }
    }
}
