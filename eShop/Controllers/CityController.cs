using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShop.EF;
using eShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace eShop.Controllers
{
    public class CityController : Controller
    {
        MyContext dbContext = new MyContext();
        // GET: City
        public ActionResult Index()
        {
            List<City> cities = dbContext.City.ToList();
            return View(cities);
        }

        // GET: City/Details/5
        public ActionResult Details(int id)
        {
            City city = dbContext.City.FirstOrDefault(x => x.ID == id);
            return View(city);
        }

        // GET: City/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: City/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(City city)
        {
            try
            {
                dbContext.Add(city);
                dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            City city = dbContext.City.FirstOrDefault(x => x.ID == id);
            return View(city);
        }

        // POST: City/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, City city)
        {
            try
            {
                // TODO: Add update logic here
                dbContext.Update(city);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: City/Delete/5
        public ActionResult Delete(int id)
        {
            City city = dbContext.City.FirstOrDefault(x => x.ID == id);
            return View(city);
        }

        // POST: City/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, City city)
        {
            try
            {
                dbContext.Remove(city);
                dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}