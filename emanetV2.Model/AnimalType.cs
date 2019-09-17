using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emanetV2.Model
{
    public class AnimalType : BaseEntity
    {
        [DisplayName("Hayvan Türü")]
        public string Name { get; set; }

    }
}
