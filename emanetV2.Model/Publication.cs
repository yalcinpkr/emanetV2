using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emanetV2.Model
{
    public class Publication : BaseEntity
    {
       
        public string Title { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }
        public string Photo { get; set; }
        public string Note { get; set; }
        public int AnimalTypeId { get; set; }
        public virtual AnimalType AnimalType { get; set; }
        public int AnimalSizeId { get; set; }
        public virtual AnimalSize AnimalSize { get; set; }


    }


}
