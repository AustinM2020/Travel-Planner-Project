using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_Planner.Contracts
{
    public interface IRepositoryWrapper
    {
        ITravelerRepository Traveler { get; }
        IVacationRepository Vacation { get; }
        IExcursionRepository Excursion { get; }
        IInterestRepository Interest { get; }
        IHotelRepository Hotel { get; }
        IFlightRepository Flight { get; }
        void Save();
    }
}
