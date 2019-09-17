using emanetV2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [DisplayName("Not")]
        public string Note { get; set; }
        [DisplayName("Fotoğraf")]
        public string Photo { get; set; }

        // Publication
        public int Id { get; set; }
        
        [DisplayName("Başlık")]
        public string Title { get; set; }
        public string Slug { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        public IList<AnimalType> AnimalTypes { get; set; }
        public IList<AnimalSize> AnimalSizes { get; set; }


    }
}