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

        //Get Country with Id
        [HttpGet]
        public ActionResult Search(int id)
        {
            var founditem = _repository.Countries().Where(item => item.Id == id).FirstOrDefault();
            return View(founditem);
        }

        //Search Country by string name
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

        //Get Country Total Progress from the start
        [HttpGet]
        public ActionResult Total(string id)
        {
            //Country name
            ViewBag.Id = id;
            //Country ISO2 code
            ViewBag.ISO2 = _repository.GetCountryISO2(id);
            return View(_repository.GetTotal(id));
        }

        //Return result between start day and end day
        [HttpPost]
        public ActionResult Progress(string country, DateTime start, DateTime end)
        {
            //Country name
            ViewBag.Country = country;
            //Country ISO2 Code
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
