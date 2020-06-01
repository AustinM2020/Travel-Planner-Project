using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Travel_Planner.Contracts;
using Travel_Planner.Data;
using Travel_Planner.Models;
using Travel_Planner.Services;

namespace Travel_Planner.Controllers
{
    public class VacationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryWrapper _repo;
        private readonly DestinationIdService _destinationIdService;
        private readonly InterestOneService _interestOneService;
        private readonly InterestTwoService _interestTwoService;
        private readonly InterestThreeService _interestThreeService;
        private readonly AirportService _airportService;
        public VacationsController(ApplicationDbContext context, IRepositoryWrapper repo, DestinationIdService destinationIdService, InterestOneService interestOneService, InterestTwoService interestTwoService, InterestThreeService interestThreeService, AirportService airportService)
        {
            _context = context;
            _repo = repo;
            _destinationIdService = destinationIdService;
            _interestOneService = interestOneService;
            _interestTwoService = interestTwoService;
            _interestThreeService = interestThreeService;
            _airportService = airportService;
        }

        public async Task<IActionResult> Index(int? Id, TravelerPlacesViewModel travelerPlaces)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var traveler = await _repo.Traveler.GetTraveler(userId);
            Vacation vacation = new Vacation();
            if(Id != null && Id.Value > 0)
            {
                traveler.VacationId = Id.Value;
                _repo.Traveler.EditTraveler(traveler);
                _repo.Save();
            }
            vacation = await _repo.Vacation.GetVacation(traveler.VacationId);
            var hotels = await _repo.Hotel.GetHotels(vacation.Id);
            if(hotels.Count > 0)
            {
                travelerPlaces.Hotels = hotels[0];
            }
            var flights = await _repo.Flight.GetFlights(vacation.Id);
            if (flights.Count > 0)
            {
                travelerPlaces.Flight = flights[0];
            }
            var excursions = await _repo.Excursion.GetExcursions(vacation.Id);
            travelerPlaces.Excursions = excursions.OrderByDescending(e => e.Importance).ToList();
            travelerPlaces.PlacesOne = await _interestOneService.GetInterestOnePlaces(traveler, vacation);
            travelerPlaces.PlacesTwo = await _interestTwoService.GetInterestTwoPlaces(vacation, traveler);
            travelerPlaces.PlacesThree = await _interestThreeService.GetInterestThreePlaces(vacation, traveler);
            travelerPlaces.Traveler = traveler;
            travelerPlaces.Vacation = vacation;
            return View(travelerPlaces);
        }
        //public async Task<IActionResult> Index(string destinationId, DateTime checkIn, DateTime checkOut, int adults, int childs, int rooms)
        //{
        //    Hotel hotel = new Hotel();
        //    hotel.CheckIn = checkIn;
        //    hotel.NumberOfAdults = adults;
        //    hotel.NumberOfRooms = rooms;
        //    HotelApi hotelApi = await _hotelService.GetHotels(destinationId, hotel);
        //    TravelerPlacesViewModel travelerPlaces = new TravelerPlacesViewModel();
        //    travelerPlaces.Hotels = hotelApi;
        //    return await Index(0, travelerPlaces);
        //}
        
        public async Task<IActionResult> AddHotel(int vacationId, DateTime addCheckIn, string addName, int addNights, int addAdults, int addRooms, string addRate, string linkName, string link)
        {
            var hotels = await _repo.Hotel.GetHotels(vacationId);
            if (hotels.Count == 0)
            {
                Hotel hotel = new Hotel();
                hotel.CheckIn = addCheckIn;
                hotel.Name = addName;
                hotel.Rate = addRate;
                hotel.NumberOfAdults = addAdults;
                hotel.NumberOfRooms = addRooms;
                hotel.Nights = addNights;
                hotel.VacationId = vacationId;
                hotel.LinkName = linkName;
                hotel.Link = link;
                _repo.Hotel.CreateHotel(hotel);
                _repo.Save();
            }
            else
            {
                hotels[0].CheckIn = addCheckIn;
                hotels[0].Name = addName;
                hotels[0].Rate = addRate;
                hotels[0].NumberOfAdults = addAdults;
                hotels[0].NumberOfRooms = addRooms;
                hotels[0].Nights = addNights;
                hotels[0].VacationId = vacationId;
                hotels[0].LinkName = linkName;
                hotels[0].Link = link;
                _repo.Hotel.EditHotel(hotels[0]);
                _repo.Save();
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> AddFlight(int vacationId, string airports, string flightPrice)
        {
            var flights = await _repo.Flight.GetFlights(vacationId);
            if(flights.Count == 0)
            {
                Flight flight = new Flight();
                flight.VacationId = vacationId;
                flight.Flights = airports;
                flight.Price = flightPrice;
                _repo.Flight.CreateFlight(flight);
                _repo.Save();
            }
            else
            {
                flights[0].VacationId = vacationId;
                flights[0].Flights = airports;
                flights[0].Price = flightPrice;
                _repo.Flight.EditFlight(flights[0]);
                _repo.Save();
            }
            return RedirectToAction("Index");
        }
        public IActionResult addExcur(int vacationId, string name, int Importance, string category)
        {
            Excursion excursion = new Excursion();
            excursion.Name = name;
            excursion.Importance = Importance;
            excursion.Category = category;
            excursion.VacationId = vacationId;
            _repo.Excursion.CreateExcursion(excursion);
            _repo.Save();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteExcur(int Id)
        {
            _repo.Excursion.DeleteExcursion(Id);
            _repo.Save();
            return RedirectToAction("Index");
        }
       
        public async Task<IActionResult> Create(Vacation vacation)
        {
            if (ModelState.IsValid)
            {
                DestinationInfo info = await _destinationIdService.GetDestinationId(vacation);
                vacation.DestinationId = info.data[0].result_object.location_id;
                _repo.Vacation.CreateVacation(vacation);
                _repo.Save();
                return RedirectToAction("Index", "Traveler");
            }
            ViewData["TravelerId"] = new SelectList(_context.Travelers, "Id", "Id", vacation.TravelerId);
            return RedirectToAction("Index", "Traveler");
        }
        

        // GET: Vacations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            _repo.Vacation.DeleteVacation(id.Value);
            _repo.Save();
            return RedirectToAction("Index", "Traveler");
        }


        private bool VacationExists(int id)
        {
            return _context.Vacations.Any(e => e.Id == id);
        }
    }

}

