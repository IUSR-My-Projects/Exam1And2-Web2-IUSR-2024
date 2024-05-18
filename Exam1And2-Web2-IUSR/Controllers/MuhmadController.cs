using Exam1And2_Web2_IUSR.Context;
using Exam1And2_Web2_IUSR.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exam1And2_Web2_IUSR.Controllers;

public class MuhmadController : Controller
{
    private readonly MyDbContext _context;

    public MuhmadController(MyDbContext context)
    {
        _context = context;
    }

    // GET
    public IActionResult Index()
    {
        var customers = _context.customers.ToList();
        ViewData["Customers"] = customers;
        return View();
    }


    // GET: Customer/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Customer/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(
        [Bind("Id,Fname,Lname,Father,PostalCode,Email,phoneNumber")] customer customer)
    {
        if (ModelState.IsValid)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        return RedirectToAction("Index");
    }
}