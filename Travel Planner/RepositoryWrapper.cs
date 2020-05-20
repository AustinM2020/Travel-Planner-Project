using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travel_Planner.Contracts;
using Travel_Planner.Data;

namespace Travel_Planner
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ApplicationDbContext _context;
        private ITravelerRepository _traveler;
        private IVacationRepository _vacation;
        private IExcursionRepository _excursion;
        private IInterestRepository _interest;
        public ITravelerRepository Traveler
        {
            get
            {
                if (_traveler == null)
                {
                    _traveler = new TravelerRepository(_context);
                }
                return _traveler;
            }
        }
        public IVacationRepository Vacation
        {
            get
            {
                if (_vacation == null)
                {
                    _vacation = new VacationRepository(_context);
                }
                return _vacation;
            }
        }
        public IExcursionRepository Excursion
        {
            get
            {
                if (_excursion == null)
                {
                    _excursion = new ExcursionRepository(_context);
                }
                return _excursion;
            }
        }
        public IInterestRepository Interest
        {
            get
            {
                if (_interest == null)
                {
                    _interest = new InterestRepository(_context);
                }
                return _interest;
            }
        }
        public RepositoryWrapper(ApplicationDbContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
