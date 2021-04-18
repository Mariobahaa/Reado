using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OBS.Models;
using OBS.Services;

namespace OBS.Controllers
{
    public class UserBooksController : Controller
    {
        private readonly IUserBookService bs;

        public UserBooksController(IUserBookService bookService)
        {
            bs = bookService;
        }

        // GET: UserBooks
        public async Task<IActionResult> Index()
        {
            
            return View(await bs.GetAll());
        }

        // GET: UserBooks/Details/5
        public async Task<IActionResult> Details(int id)
        {
            
            string UID = User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "NAN";

            var userBook = await bs.GetDetails(id, UID);
            if (userBook == null)
            {
                return NotFound();
            }

            return View(userBook);
        }

        // GET: UserBooks/Create
        public IActionResult Create()
        {
            ////////////////////////Edit Here Tomorrow ////////////////////////////
            // ViewData["BookId"] = new SelectList(_context.Books, "Id", "Author");
            return View();
        }

        // POST: UserBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,UserId,Rating")] UserBook userBook)
        {
            if (ModelState.IsValid)
            {
                bs.Insert(userBook);
                return RedirectToAction(nameof(Index));
            }
            ////////////////////////Edit Here Tomorrow ////////////////////////////
            //ViewData["BookId"] = new SelectList(_context.Books, "Id", "Author", userBook.BookId);
            return View(userBook);
        }

        // GET: UserBooks/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var userBook = await _context.UserBooks.FindAsync(id);
        //    if (userBook == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["BookId"] = new SelectList(_context.Books, "Id", "Author", userBook.BookId);
        //    return View(userBook);
        //}

        //// POST: UserBooks/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("BookId,UserId,Rating")] UserBook userBook)
        //{
        //    if (id != userBook.BookId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(userBook);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UserBookExists(userBook.BookId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["BookId"] = new SelectList(_context.Books, "Id", "Author", userBook.BookId);
        //    return View(userBook);
        //}

        //// GET: UserBooks/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var userBook = await _context.UserBooks
        //        .Include(u => u.Book)
        //        .FirstOrDefaultAsync(m => m.BookId == id);
        //    if (userBook == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(userBook);
        //}

        //// POST: UserBooks/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var userBook = await _context.UserBooks.FindAsync(id);
        //    _context.UserBooks.Remove(userBook);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool UserBookExists(int id)
        //{
        //    return _context.UserBooks.Any(e => e.BookId == id);
        //}
    }
}
