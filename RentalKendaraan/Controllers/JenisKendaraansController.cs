﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RentalKendaraan.Models;

namespace RentalKendaraan.Controllers
{
    public class JenisKendaraansController : Controller
    {
        private readonly RentalKendaraanContext _context;

        public JenisKendaraansController(RentalKendaraanContext context)
        {
            _context = context;
        }

        // GET: JenisKendaraans
        public async Task<IActionResult> Index(string ktsd, string searchString, string sortOrder, string currentFilter, int? pageNumber)
        {
            var ktsdList = new List<string>();
            var ktsdQuery = from d in _context.JenisKendaraans orderby d.NamaJenisKendaraan select d.NamaJenisKendaraan;
            ktsdList.AddRange(ktsdQuery.Distinct());
            ViewBag.ktsd = new SelectList(ktsdList);
            var menu = from m in _context.JenisKendaraans select m;
            if (!string.IsNullOrEmpty(ktsd))
            {
                menu = menu.Where(x => x.NamaJenisKendaraan == ktsd);
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                menu = menu.Where(s => s.NamaJenisKendaraan.Contains(searchString));
            }
            return View(await menu.ToListAsync());
        }

        // GET: JenisKendaraans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jenisKendaraan = await _context.JenisKendaraans
                .FirstOrDefaultAsync(m => m.IdJenisKendaraan == id);
            if (jenisKendaraan == null)
            {
                return NotFound();
            }

            return View(jenisKendaraan);
        }

        // GET: JenisKendaraans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JenisKendaraans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdJenisKendaraan,NamaJenisKendaraan")] JenisKendaraan jenisKendaraan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jenisKendaraan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jenisKendaraan);
        }

        // GET: JenisKendaraans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jenisKendaraan = await _context.JenisKendaraans.FindAsync(id);
            if (jenisKendaraan == null)
            {
                return NotFound();
            }
            return View(jenisKendaraan);
        }

        // POST: JenisKendaraans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdJenisKendaraan,NamaJenisKendaraan")] JenisKendaraan jenisKendaraan)
        {
            if (id != jenisKendaraan.IdJenisKendaraan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jenisKendaraan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JenisKendaraanExists(jenisKendaraan.IdJenisKendaraan))
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
            return View(jenisKendaraan);
        }

        // GET: JenisKendaraans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jenisKendaraan = await _context.JenisKendaraans
                .FirstOrDefaultAsync(m => m.IdJenisKendaraan == id);
            if (jenisKendaraan == null)
            {
                return NotFound();
            }

            return View(jenisKendaraan);
        }

        // POST: JenisKendaraans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jenisKendaraan = await _context.JenisKendaraans.FindAsync(id);
            _context.JenisKendaraans.Remove(jenisKendaraan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JenisKendaraanExists(int id)
        {
            return _context.JenisKendaraans.Any(e => e.IdJenisKendaraan == id);
        }
    }
}
