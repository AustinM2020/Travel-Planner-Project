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
        private readonly HotelService _hotelService;
        private readonly AirportService _airportService;
        public VacationsController(ApplicationDbContext context, IRepositoryWrapper repo, DestinationIdService destinationIdService, InterestOneService interestOneService, InterestTwoService interestTwoService, InterestThreeService interestThreeService, HotelService hotelService, AirportService airportService)
        {
            _context = context;
            _repo = repo;
            _destinationIdService = destinationIdService;
            _interestOneService = interestOneService;
            _interestTwoService = interestTwoService;
            _interestThreeService = interestThreeService;
            _hotelService = hotelService;
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
            travelerPlaces.PlacesOne = await _interestOneService.GetInterestOnePlaces(traveler, vacation);
            travelerPlaces.PlacesTwo = await _interestTwoService.GetInterestTwoPlaces(vacation, traveler);
            travelerPlaces.PlacesThree = await _interestThreeService.GetInterestThreePlaces(vacation, traveler);
            travelerPlaces.Traveler = traveler;
            travelerPlaces.Vacation = vacation;
            return View(travelerPlaces);
        }
        [HttpPost]
        public async Task<IActionResult> Index(string destinationId, DateTime checkIn, DateTime checkOut, int adults, int childs, int rooms)
        {
            Hotel hotel = new Hotel();
            hotel.CheckIn = checkIn;
            hotel.CheckOut = checkOut;
            hotel.NumberOfAdults = adults;
            hotel.NumberOfChildren = childs;
            hotel.NumberOfRooms = rooms;
            HotelApi hotelApi = await _hotelService.GetHotels(destinationId, hotel);
            TravelerPlacesViewModel travelerPlaces = new TravelerPlacesViewModel();
            travelerPlaces.Hotels = hotelApi;
            return await Index(0, travelerPlaces);
        }
        //public async Task<IActionResult> GetHotels()
        //{
            
        //    return await Index(hotelApi);
        //}
        public string GetState(string state)
        {
            switch (state)
            {
                case "AL":
                    return "ALABAMA";

                case "AK":
                    return "ALASKA";

                case "AS":
                    return "AMERICAN SAMOA";

                case "AZ":
                    return "ARIZONA";

                case "AR":
                    return "ARKANSAS";

                case "CA":
                    return "CALIFORNIA";

                case "CO":
                    return "COLORADO";

                case "CT":
                    return "CONNECTICUT";

                case "DE":
                    return "DELAWARE";

                case "DC":
                    return "DISTRICT OF COLUMBIA";

                case "FM":
                    return "FEDERATED STATES OF MICRONESIA";

                case "FL":
                    return "FLORIDA";

                case "GA":
                    return "GEORGIA";

                case "GU":
                    return "GUAM";

                case "HI":
                    return "HAWAII";

                case "ID":
                    return "IDAHO";

                case "IL":
                    return "ILLINOIS";

                case "IN":
                    return "INDIANA";

                case "IA":
                    return "IOWA";

                case "KS":
                    return "KANSAS";

                case "KY":
                    return "KENTUCKY";

                case "LA":
                    return "LOUISIANA";

                case "ME":
                    return "MAINE";

                case "MH":
                    return "MARSHALL ISLANDS";

                case "MD":
                    return "MARYLAND";

                case "MA":
                    return "MASSACHUSETTS";

                case "MI":
                    return "MICHIGAN";

                case "MN":
                    return "MINNESOTA";

                case "MS":
                    return "MISSISSIPPI";

                case "MO":
                    return "MISSOURI";

                case "MT":
                    return "MONTANA";

                case "NE":
                    return "NEBRASKA";

                case "NV":
                    return "NEVADA";

                case "NH":
                    return "NEW HAMPSHIRE";

                case "NJ":
                    return "NEW JERSEY";

                case "NM":
                    return "NEW MEXICO";

                case "NY":
                    return "NEW YORK";

                case "NC":
                    return "NORTH CAROLINA";

                case "ND":
                    return "NORTH DAKOTA";

                case "MP":
                    return "NORTHERN MARIANA ISLANDS";

                case "OH":
                    return "OHIO";

                case "OK":
                    return "OKLAHOMA";

                case "OR":
                    return "OREGON";

                case "PW":
                    return "PALAU";

                case "PA":
                    return "PENNSYLVANIA";

                case "PR":
                    return "PUERTO RICO";

                case "RI":
                    return "RHODE ISLAND";

                case "SC":
                    return "SOUTH CAROLINA";

                case "SD":
                    return "SOUTH DAKOTA";

                case "TN":
                    return "TENNESSEE";

                case "TX":
                    return "TEXAS";

                case "UT":
                    return "UTAH";

                case "VT":
                    return "VERMONT";

                case "VI":
                    return "VIRGIN ISLANDS";

                case "VA":
                    return "VIRGINIA";

                case "WA":
                    return "WASHINGTON";

                case "WV":
                    return "WEST VIRGINIA";

                case "WI":
                    return "WISCONSIN";

                case "WY":
                    return "WYOMING";
            }

            throw new Exception("Not Available");
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacation = await _context.Vacations
                .Include(v => v.Traveler)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacation == null)
            {
                return NotFound();
            }

            return View(vacation);
        }
        public async Task<IActionResult> Create(Vacation vacation)
        {
            if (ModelState.IsValid)
            {
                DestinationInfo info = await _destinationIdService.GetDestinationId(vacation);
                string city = vacation.Destination.Substring(0, vacation.Destination.IndexOf(","));
                for (int i = 0; i < info.suggestions[0].entities.Length; i++)
                {
                    if (info.suggestions[0].entities[i].name.ToUpper() == city.ToUpper())
                    {
                        vacation.DestinationId = info.suggestions[0].entities[i].destinationId;
                        break;
                    }
                }
                _repo.Vacation.CreateVacation(vacation);
                _repo.Save();
                return RedirectToAction("Index", "Traveler");
            }
            ViewData["TravelerId"] = new SelectList(_context.Travelers, "Id", "Id", vacation.TravelerId);
            return RedirectToAction("Index", "Traveler");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacation = await _context.Vacations.FindAsync(id);
            if (vacation == null)
            {
                return NotFound();
            }
            ViewData["TravelerId"] = new SelectList(_context.Travelers, "Id", "Id", vacation.TravelerId);
            return View(vacation);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Destination,DestinationId,VacationStart,VacationEnd,Lat,Long,TravelerId")] Vacation vacation)
        {
            if (id != vacation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacationExists(vacation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TravelerId"] = new SelectList(_context.Travelers, "Id", "Id", vacation.TravelerId);
            return View(vacation);
        }

        // GET: Vacations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vacation = await _context.Vacations
                .Include(v => v.Traveler)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacation == null)
            {
                return NotFound();
            }

            return View(vacation);
        }

        // POST: Vacations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vacation = await _context.Vacations.FindAsync(id);
            _context.Vacations.Remove(vacation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacationExists(int id)
        {
            return _context.Vacations.Any(e => e.Id == id);
        }
    }

}

