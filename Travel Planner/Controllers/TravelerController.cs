﻿using System;
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
    public class TravelerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IRepositoryWrapper _repo;
        private readonly HotelService _hotelService;
        public TravelerController(ApplicationDbContext context, IRepositoryWrapper repo, HotelService hotelService)
        {
            _context = context;
            _repo = repo;
            _hotelService = hotelService;
        }
        
        
        // GET: Traveler
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var traveler = await _repo.Traveler.GetTraveler(userId);
            //var item = traveler.Interests[0];
            if(traveler == null)
            {
                return RedirectToAction("Create");
            }
            //HotelApi hotels = await _hotelService.GetHotels(vacation);
            return View(traveler);
        }
        public List<SelectListItem> CreateInterestsSelectList()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem() { Text = "Parks", Value = "Parks" });
            items.Add(new SelectListItem() { Text = "Art", Value = "Art" });
            items.Add(new SelectListItem() { Text = "Museums", Value = "Museums" });
            items.Add(new SelectListItem() { Text = "Local Attractions", Value = "Attractions" });
            items.Add(new SelectListItem() { Text = "Live Music", Value = "Live Music" });
            items.Add(new SelectListItem() { Text = "Nightlife", Value = "Nightlife" });
            items.Add(new SelectListItem() { Text = "Movies", Value = "Movies" });
            return items;
        }
        // GET: Traveler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traveler = await _repo.Traveler.GetTraveler(id);
            if (traveler == null)
            {
                return NotFound();
            }

            return View(traveler);
        }

        // GET: Traveler/Create
        public IActionResult Create()
        {
            ViewData["Interests"] = new SelectList(_context.Interests, "Id", "Name");
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Traveler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,StreetAddress,City,State,ZipCode,InterestOne,InterestTwo,InterestThree,Lat,Long,IdentityUserId")] Traveler traveler)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                traveler.IdentityUserId = userId;
                _repo.Traveler.CreateTraveler(traveler);
                _repo.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", traveler.IdentityUserId);
            return View(traveler);
        }

        // GET: Traveler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traveler = await _repo.Traveler.GetTraveler(id);
            if (traveler == null)
            {
                return NotFound();
            }
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", traveler.IdentityUserId);
            return View(traveler);
        }

        // POST: Traveler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,StreetAddress,City,State,ZipCode,Lat,Long,IdentityUserId")] Traveler traveler)
        {
            if (id != traveler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                    traveler.IdentityUserId = userId;
                    _repo.Traveler.EditTraveler(traveler);
                    _repo.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelerExists(traveler.Id))
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
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", traveler.IdentityUserId);
            return View(traveler);
        }

        // GET: Traveler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traveler = await _repo.Traveler.GetTraveler(id);
            if (traveler == null)
            {
                return NotFound();
            }

            return View(traveler);
        }

        // POST: Traveler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var traveler = await _repo.Traveler.GetTraveler(id);
            _repo.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelerExists(int id)
        {
            return _context.Travelers.Any(e => e.Id == id);
        }
    }
}
