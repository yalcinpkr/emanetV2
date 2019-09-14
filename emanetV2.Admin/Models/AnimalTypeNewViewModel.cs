using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace emanetV2.Admin.Models
{
    public class AnimalTypeNewViewModel
    {
        public string Name { get; set; }
        public int StatusId { get; set; }
        public IList<Status> Statuses { get; set; }
    }
}