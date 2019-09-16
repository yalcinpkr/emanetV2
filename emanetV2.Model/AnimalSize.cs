using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emanetV2.Model
{
    public class AnimalSize : BaseEntity
    {
        [DisplayName("Hayvan Boyutu")]
        public string Name { get; set; }


    }
}
