using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CovidAssignment.Models
{
    public class CovidApiProperty
    {
        public string EndPoint { get; }

        public CovidApiProperty()
        {
            EndPoint = ConfigurationManager.AppSettings["CovidApiEndPoint"];
        }
    }
}