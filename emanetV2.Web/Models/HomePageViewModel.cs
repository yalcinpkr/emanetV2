using emanetV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emanetV2.Web.Models
{
    public class HomePageViewModel
    {
        public IList<Publication> LastPublications { get; set; }
    }
}