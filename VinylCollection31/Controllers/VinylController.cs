using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VinylCollection31.Models;

namespace VinylCollection31.Controllers
{
   
        public class VinylController : Controller
        {
            //Add a readonly version of DbContext
            private readonly ApplicationDbContext _db;

            public VinylController(ApplicationDbContext db)
            {
                _db = db;
            }

            // GET: Vinyl
            public ActionResult Index()
            {
                return View(_db.Records.OrderBy(r => r.Artist).ThenBy(r => r.Title).ToList());
            }

            // GET: Vinyl/Details/5
            public async Task<IActionResult> Details(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var record = await _db.Records.SingleOrDefaultAsync(r => r.Id == id);

                if (record == null)
                {
                    return NotFound();
                }

                return View(record);
            }

            // GET: Vinyl/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Vinyl/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(Record record)
            {
                if (ModelState.IsValid)
                {
                    _db.Add(record);
                    await _db.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }

                //if not valid, just return recored back to the view
                return View(record);
            }

            // GET: Vinyl/Edit/5
            public async Task<IActionResult> Edit(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var record = await _db.Records.SingleOrDefaultAsync(r => r.Id == id);

                if (record == null)
                {
                    return NotFound();
                }
                return View(record);
            }

            // POST: Vinyl/Edit/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(int id, Record record)
            {
                if (id != record.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    _db.Update(record);
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

                return View(record);

            }


            // GET: Vinyl/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

                var record = await _db.Records.SingleOrDefaultAsync(r => r.Id == id);

                if (record == null)
                {
                    return NotFound();
                }

                return View(record);

            }

            // POST: Vinyl/Delete/5
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Delete(int id)
            {
                var record = await _db.Records.SingleOrDefaultAsync(r => r.Id == id);

                if (record == null)
                {
                    return NotFound();
                }

                _db.Remove(record);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }

        }
    }
