using emanetV2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace emanetV2.Admin.Models
{
    public class AnimalTypeNewViewModel
    {
        [DisplayName("Hayvan Türü")]
        public string Name { get; set; }
        [DisplayName("Durumu")]
        public int StatusId { get; set; }
        public IList<Status> Statuses { get; set; }
    }
}