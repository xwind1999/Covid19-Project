using CovidAssignment.Models;
using CovidAssignment.Repository;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CovidAssignment.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountryRepository _repository;
        public CountriesController(ICountryRepository repository)
        {
            _repository = repository;
        }
        // GET: Countries
        public ActionResult Index()
        {
            ViewBag.Global = _repository.GetGlobal();
            return View(_repository.Countries());
        }


        [HttpGet]
        public ActionResult Search(int id)
        {
            var founditem = _repository.Countries().Where(item => item.Id == id).FirstOrDefault();
            return View(founditem);
        }

        [HttpPost]
        public ActionResult Search(string countrySearch)
        {
            if (!String.IsNullOrEmpty(countrySearch))
            {
                var listFilter = _repository.Countries().Where(item => item.Name.Contains(countrySearch)).FirstOrDefault();
                return View(listFilter);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Total(string id)
        {
            ViewBag.Id = id;
            ViewBag.ISO2 = _repository.GetCountryISO2(id);
            return View(_repository.GetTotal(id));
        }

        [HttpPost]
        public ActionResult Progress(string country, DateTime start, DateTime end)
        {
            ViewBag.Country = country;
            ViewBag.ISO2 = _repository.GetCountryISO2(country);
            return View(_repository.GetProgress(country,start,end));
        }

        // GET: Countries/Details/5
        public ActionResult Details(int id)
        {
            var foundItem = _repository.Countries().Where(item => item.Id == id).FirstOrDefault();
            return View(foundItem);
        }
    }
}
