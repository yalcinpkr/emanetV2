﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emanetV2.Web.Models
{
    public class MemberNewPublicationViewModel
    {

        // Animal
        public int AnimalSizeId { get; set; }

        public int AnimalTypeId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Note { get; set; }

        // Publication
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }

        public IList<AnimalType> AnimalTypes { get; set; }
        public IList<AnimalSize> AnimalSizes { get; set; }


    }
}