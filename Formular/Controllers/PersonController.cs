using Formular.Data;
using Formular.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Formular.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PersonController(ApplicationDbContext db)
        {
            _db = db;
        }

        // **** Add ****

        // Get
        public IActionResult Add()
        {
            return View();
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Person p)
        {
            if(ModelState.IsValid)
            {
                _db.Persons.Add(p);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        // **** Delete ****

        // Get
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Persons.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Persons.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Persons.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // **** Update ****

        // Get
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Persons.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Person p)
        {
            if (ModelState.IsValid)
            {
                _db.Persons.Update(p);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }


        // **** Select & Search ****

        // GET
        public IActionResult Index(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                IEnumerable<Person> listPerson = _db.Persons;
                return View(listPerson);
            }
            else
            {
                IEnumerable<Person> listPerson = _db.Persons.Where(x => x.Name.Contains(search) || x.Ort.Contains(search) || x.PLZ.Contains(search) || x.PAlter.Contains(search) || x.Email.Contains(search));
                return View(listPerson);
            }
        }
    }
}
