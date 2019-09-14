using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emanetV2.Model
{
    public class Animal : BaseEntity
    {
        public int? AnimalSizeId { get; set; }
        public virtual AnimalSize AnimalSize { get; set; }

        public int? AnimalTypeId { get; set; }
        public virtual AnimalType AnimalType { get; set; }

        public string Note { get; set; }


    }
}
