using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HMS;
using HMS.Models;
using Microsoft.Extensions.Hosting;

namespace HMS.Controllers
{
    public class HostelsController : Controller
    {
        private readonly HMSDbcontext _context;

        public HostelsController(HMSDbcontext context)
         {
            _context = context;
        }

        // GET: Hostels
        public async Task<IActionResult> Index()
        {
              return View(await _context.Hostels.ToListAsync());
        }

        // GET: Hostels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hostels == null)
            {
                return NotFound();
            }

            var hostel = await _context.Hostels
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hostel == null)
            {
                return NotFound();
            }

            return View(hostel);
        }

        // GET: Hostels/Create
        public IActionResult Create()
        {
            
            
            return View();
        }

        // POST: Hostels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Hostel hostel)
        {
           //var profileImage = hostel.ProfileImage;
            
           // var fileName = profileImage.FileName;
           // var uniqueFileName =$"{Guid.NewGuid()}_{fileName}";
           // var relativePath = $"/Images/Profiles/{uniqueFileName}";
           // var currentAppPath = Directory.GetCurrentDirectory();
           //var fullFilePath = Path.Combine(currentAppPath,$"wwwroot/{relativePath}");

           // var stream = System.IO.File.Create(fullFilePath);
           // profileImage.CopyTo(stream);

            var relativePath = saveProfileImage(hostel.ProfileImage);
           // hostel.ProfileImagePath = relativePath;
            
            if (ModelState.IsValid)
            {
                hostel.ProfileImagePath = relativePath;
                _context.Hostels.Add(hostel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hostel);
        }

        // GET: Hostels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
            if (id == null || _context.Hostels == null)
            {
                return NotFound();
            }

            var hostel = await _context.Hostels.FindAsync(id);
            if (hostel == null)
            {
                return NotFound();
            }
            return View(hostel);
        }

        // POST: Hostels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,Address,Contact,Capacity,Rooms,Seaters,EmptySeats,Fees")] Hostel hostel)
        {
            if (id != hostel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var relativePath = saveProfileImage(hostel.ProfileImage);
                try
                {
                    hostel.ProfileImagePath = relativePath;
                    _context.Update(hostel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HostelExists(hostel.ID))
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
            return View(hostel);
        }

        // GET: Hostels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hostels == null)
            {
                return NotFound();
            }

            var hostel = await _context.Hostels
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hostel == null)
            {
                return NotFound();
            }

            return View(hostel);
        }

        // POST: Hostels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hostels == null)
            {
                return Problem("Entity set 'HMSDbcontext.Hostels'  is null.");
            }
            var hostel = await _context.Hostels.FindAsync(id);
            if (hostel != null)
            {
                _context.Hostels.Remove(hostel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HostelExists(int id)
        {
          return _context.Hostels.Any(e => e.ID == id);
        }


        private string saveProfileImage(IFormFile profileImage)
        {
           

            var fileName = profileImage.FileName;
            var uniqueFileName = $"{Guid.NewGuid()}_{fileName}";
            var relativePath = $"/Images/Profiles/{uniqueFileName}";
            var currentAppPath = Directory.GetCurrentDirectory();
            var fullFilePath = Path.Combine(currentAppPath, $"wwwroot/{relativePath}");

            var stream = System.IO.File.Create(fullFilePath);
            profileImage.CopyTo(stream);
            return relativePath;
        }
    }
}
