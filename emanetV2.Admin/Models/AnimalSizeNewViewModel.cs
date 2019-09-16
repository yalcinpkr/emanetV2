using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace emanetV2.Admin.Models
{
    public class AnimalSizeNewViewModel
    {
         [DisplayName("Hayvan Boyutu")]
        public string Name { get; set; }
        [DisplayName("Durumu")]
        public int StatusId { get; set; }
    }
}