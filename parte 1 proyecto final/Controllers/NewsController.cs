using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parte_1_proyecto_final.Models;

namespace parte_1_proyecto_final.Controllers
{
    [Authorize(Roles = "Editor")]
    public class NewsController : Controller
    {
        private readonly newspageContext _context;

        public NewsController(newspageContext context)
        {
            _context = context;
        }

        // GET: News
        public async Task<IActionResult> Index()
        {
            var newspageContext = _context.News.Include(n => n.Author).Include(n => n.Category).Include(n => n.Country).Include(n => n.User);
            return View(await newspageContext.ToListAsync());
        }

        // GET: News/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .Include(n => n.Author)
                .Include(n => n.Category)
                .Include(n => n.Country)
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.NewsId == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // GET: News/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "Author1");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Category1");
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "Country1");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email");
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NewsId,CountryId,AuthorId,CategoryId,Title,Content,Link,UrlToImage,PublishedAt,UserId")] News news)
        {
            if (ModelState.IsValid)
            {
                _context.Add(news);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorId", news.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", news.CategoryId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryId", news.CountryId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", news.UserId);
            return View(news);
        }

        // GET: News/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "Author1", news.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Category1", news.CategoryId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "Country1", news.CountryId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Email", news.UserId);
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NewsId,CountryId,AuthorId,CategoryId,Title,Content,Link,UrlToImage,PublishedAt,UserId")] News news)
        {
            if (id != news.NewsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(news);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NewsExists(news.NewsId))
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
            ViewData["AuthorId"] = new SelectList(_context.Authors, "AuthorId", "AuthorId", news.AuthorId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", news.CategoryId);
            ViewData["CountryId"] = new SelectList(_context.Countries, "CountryId", "CountryId", news.CountryId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", news.UserId);
            return View(news);
        }

        // GET: News/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var news = await _context.News
                .Include(n => n.Author)
                .Include(n => n.Category)
                .Include(n => n.Country)
                .Include(n => n.User)
                .FirstOrDefaultAsync(m => m.NewsId == id);
            if (news == null)
            {
                return NotFound();
            }

            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var news = await _context.News.FindAsync(id);
            _context.News.Remove(news);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(e => e.NewsId == id);
        }
    }
}
