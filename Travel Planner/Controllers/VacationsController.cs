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
        public VacationsController(ApplicationDbContext context, IRepositoryWrapper repo, DestinationIdService destinationIdService, InterestOneService interestOneService, InterestTwoService interestTwoService, InterestThreeService interestThreeService)
        {
            _context = context;
            _repo = repo;
            _destinationIdService = destinationIdService;
            _interestOneService = interestOneService;
            _interestTwoService = interestTwoService;
            _interestThreeService = interestThreeService;
        }

        // GET: Vacations
        public async Task<IActionResult> Index(int Id)
        {
            TravelerPlacesViewModel travelerPlaces = new TravelerPlacesViewModel();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var traveler = await _repo.Traveler.GetTraveler(userId);
            var vacation = await _repo.Vacation.GetVacation(Id);
            travelerPlaces.PlacesOne = await _interestOneService.GetInterestOnePlaces(traveler, vacation);
            travelerPlaces.PlacesTwo = await _interestTwoService.GetInterestTwoPlaces(vacation, traveler);
            travelerPlaces.PlacesThree = await _interestThreeService.GetInterestThreePlaces(vacation, traveler);
            travelerPlaces.Vacation = vacation;
            travelerPlaces.Traveler = traveler;
            return View(travelerPlaces);
        }

        // GET: Vacations/Details/5
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
                for(int i = 0; i < info.suggestions[0].entities.Length; i++)
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

        // GET: Vacations/Edit/5
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

        // POST: Vacations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
