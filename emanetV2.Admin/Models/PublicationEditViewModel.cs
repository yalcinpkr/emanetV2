using emanetV2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emanetV2.Admin.Models
{
    public class PublicationEditViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }
        public string Note { get; set; }
        public int AnimalTypeId { get; set; }

        public int AnimalSizeId { get; set; }
        public int StatusId { get; set; }

        public IList<AnimalType> AnimalTypes { get; set; }
        public IList<AnimalSize> AnimalSizes { get; set; }

    }
}