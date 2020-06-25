using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eShop.EF;
using eShop.Models;

namespace eShop.Controllers
{
    public class InvoiceProductsController : Controller
    {
        private readonly MyContext _context = new MyContext();

        // GET: InvoiceProducts
        public async Task<IActionResult> Index()
        {
            var myContext = _context.InvoiceProduct.Include(i => i.Invoice).Include(i => i.Product);
            return View(await myContext.ToListAsync());
        }

        // GET: InvoiceProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceProduct = await _context.InvoiceProduct
                .Include(i => i.Invoice)
                .Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (invoiceProduct == null)
            {
                return NotFound();
            }

            return View(invoiceProduct);
        }

        // GET: InvoiceProducts/Create
        public IActionResult Create()
        {
            ViewData["InvoiceID"] = new SelectList(_context.Invoice, "ID", "ID");
            ViewData["ProductID"] = new SelectList(_context.Product, "ID", "Name");
            return View();
        }

        // POST: InvoiceProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ProductID,InvoiceID,Quantity")] InvoiceProduct invoiceProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invoiceProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InvoiceID"] = new SelectList(_context.Invoice, "ID", "ID", invoiceProduct.InvoiceID);
            ViewData["ProductID"] = new SelectList(_context.Product, "ID", "Name", invoiceProduct.ProductID);
            return View(invoiceProduct);
        }

        // GET: InvoiceProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceProduct = await _context.InvoiceProduct.FindAsync(id);
            if (invoiceProduct == null)
            {
                return NotFound();
            }
            ViewData["InvoiceID"] = new SelectList(_context.Invoice, "ID", "ID", invoiceProduct.InvoiceID);
            ViewData["ProductID"] = new SelectList(_context.Product, "ID", "Name", invoiceProduct.ProductID);
            return View(invoiceProduct);
        }

        // POST: InvoiceProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ProductID,InvoiceID,Quantity")] InvoiceProduct invoiceProduct)
        {
            if (id != invoiceProduct.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invoiceProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceProductExists(invoiceProduct.ID))
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
            ViewData["InvoiceID"] = new SelectList(_context.Invoice, "ID", "ID", invoiceProduct.InvoiceID);
            ViewData["ProductID"] = new SelectList(_context.Product, "ID", "Name", invoiceProduct.ProductID);
            return View(invoiceProduct);
        }

        // GET: InvoiceProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoiceProduct = await _context.InvoiceProduct
                .Include(i => i.Invoice)
                .Include(i => i.Product)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (invoiceProduct == null)
            {
                return NotFound();
            }

            return View(invoiceProduct);
        }

        // POST: InvoiceProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var invoiceProduct = await _context.InvoiceProduct.FindAsync(id);
            _context.InvoiceProduct.Remove(invoiceProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceProductExists(int id)
        {
            return _context.InvoiceProduct.Any(e => e.ID == id);
        }
    }
}
