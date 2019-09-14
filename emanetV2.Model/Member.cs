using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace emanetV2.Model
{
    public class Member : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string TelephoneNumber { get; set; }

        public string Province { get; set; }
        public string District { get; set; }

        public bool IsActive { get; set; }
    }
}
