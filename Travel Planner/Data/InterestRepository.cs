using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_Planner.Contracts;
using Travel_Planner.Models;

namespace Travel_Planner.Data
{
    public class InterestRepository : RepositoryBase<Interest>, IInterestRepository
    {
        public InterestRepository(ApplicationDbContext applicationDbContext)
            :base(applicationDbContext)
        {
        }
    }
}
