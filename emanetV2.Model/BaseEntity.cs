using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emanetV2.Model
{
    public class BaseEntity
    {

        public int Id { get; set; }
        public int StatusId { get; set; }
        public virtual Status Status { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int? MemberId { get; set; }

    }
}
