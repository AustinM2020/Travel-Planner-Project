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
        private IHotelRepository _hotelRepository;
        private IFlightRepository _flightRepository;
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
        public IHotelRepository Hotel
        {
            get
            {
                if(_hotelRepository == null)
                {
                    _hotelRepository = new HotelRepository(_context);
                }
                return _hotelRepository;
            }
        }
        public IFlightRepository Flight
        {
            get
            {
                if (_flightRepository == null)
                {
                    _flightRepository = new FlightRepository(_context);
                }
                return _flightRepository;
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
