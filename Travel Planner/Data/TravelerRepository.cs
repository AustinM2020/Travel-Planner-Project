using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_Planner.Contracts;
using Travel_Planner.Models;

namespace Travel_Planner.Data
{
    public class TravelerRepository : RepositoryBase<Traveler>, ITravelerRepository
    {
        public TravelerRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
        }

        public void CreateTraveler(Traveler traveler)
        {
            Create(traveler);
        }

        public async void DeleteTraveler(int? travelerId)
        {
            var result = await FindByCondition(t => t.Id.Equals(travelerId));
            var traveler = result.SingleOrDefault();
            Delete(traveler);
        }

        public void EditTraveler(Traveler traveler)
        {
            Update(traveler);
        }

        public async Task<Traveler> GetTraveler(int? travelerId)
        {
            var result = await FindByCondition(t => t.Id.Equals(travelerId));
            var traveler = result.SingleOrDefault();
            return traveler;
        }

        public async Task<Traveler> GetTraveler(string userId)
        {
            var result = await FindByCondition(t => t.IdentityUserId.Equals(userId));
            var traveler = result.SingleOrDefault();
            return traveler;
        }
    }
}
