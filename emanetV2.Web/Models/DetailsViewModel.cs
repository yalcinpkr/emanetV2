﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emanetV2.Web.Models
{
    public class DetailsViewModel
    {
        public string Title { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }
        public string Photo { get; set; }
        public string Note { get; set; }
        public string AnimalType { get; set; }
        public string AnimalSize { get; set; }
      
    }
}