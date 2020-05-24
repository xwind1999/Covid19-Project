using CovidAssignment.DataContext;
using CovidAssignment.Extension;
using CovidAssignment.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CovidAssignment.Repository
{
    public interface ICountryRepository
    {
        //Return current status of all countries
        List<CountryStatus> Countries();

        //Return current global status
        Global GetGlobal();

        //Return all progress of country from the day the covid-19 start
        List<Total> GetTotal(string country);

        //Return progress of country from the start to the end of request
        List<Total> GetProgress(string country, DateTime start, DateTime end);

        //Return ISO2 of a country
        string GetCountryISO2(string countryName);
    }
    public class CountryRepository : ICountryRepository
    {
        private readonly CovidApiProperty _property;
        private readonly RestClient _client;
        private readonly CovidApiContext _context;

        //Create Repository 
        public CountryRepository(CovidApiProperty endPoint, CovidApiContext context)
        {
            _property = endPoint;

            _client = new RestClient(endPoint.EndPoint);

            _context = context;

            PullDataSummary();

            GetAllCountries();
        }

        //Get data by requesting to api and convert json type to list and save into databases
        //Get summary type
        public void PullDataSummary()
        {
            //call a request
            var getRequest = new RestRequest($"/summary", Method.GET);
            //Execute request
            var resp = _client.Execute(getRequest);
            //Response Content
            var respContent = resp.Content;
            //Convert response content to Summary type
            var summary = JsonConvert.DeserializeObject<Summary>(respContent);

            //Truncate table from database to reset id
            _context.Database.ExecuteSqlCommand("Truncate table Globals");
            _context.Database.ExecuteSqlCommand("Truncate table CountryStatus");
            _context.SaveChanges();

            //Insert to database current value
            _context.Globals.Add(summary.Global);
            _context.Countries.AddRange(summary.Countries);

            //Save Changes
            _context.SaveChanges();
        }

        //Pull All Countries from API to Databases
        public void GetAllCountries()
        {
            var getRequest = new RestRequest($"/countries", Method.GET);
            var resp = _client.Execute(getRequest);
            var respContent = resp.Content;
            var objectList = JsonConvert.DeserializeObject<List<Country>>(respContent);
            _context.Database.ExecuteSqlCommand("Truncate table Countries");
            _context.CountriesInfo.AddRange(objectList);
            _context.SaveChanges();
        }

        //Return total progress of the country from the day the covid-19 start
        public List<Total> GetTotal(string country)
        {
            var getRequest = new RestRequest($"/total/country/{country}", Method.GET);
            var resp = _client.Execute(getRequest);
            var respContent = resp.Content;
            var objectList = JsonConvert.DeserializeObject<List<Total>>(respContent);
            //Reverse the list to get nearest days on the top of the list
            objectList.Reverse();
            return objectList;
        }

        //Return progress of country from the start to the end of request
        public List<Total> GetProgress(string country, DateTime start, DateTime end)
        {
            var getRequest = new RestRequest($"/total/country/{country}", Method.GET);
            //Add request params 
            getRequest.AddParameter("from", start.StringExtension());
            getRequest.AddParameter("to", end.StringExtension());
            
            var resp = _client.Execute(getRequest);
            var respContent = resp.Content;
            var objectList = JsonConvert.DeserializeObject<List<Total>>(respContent);
            //Reverse the list to get nearest days on the top of the list
            objectList.Reverse();
            return objectList;
        }

        //Get current Global statistic, which saved in database now
        public Global GetGlobal()
        {
            return _context.Globals.First();
        }

        //return all countries current statistic, which saved in database now
        public List<CountryStatus> Countries()
        {
            return _context.Countries.ToList();
        }

        //return  ISO2 of a country. Input : Vietnam , Output : VN
        public string GetCountryISO2(string countryName)
        {
            var foundItem = _context.CountriesInfo.Where(item => item.Name == countryName).FirstOrDefault();
            return foundItem.ISO2.ToLower();
        }

    }
}