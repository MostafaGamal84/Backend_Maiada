using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orbits.GeneralProject.DTO.StudentDto
{
    public class StudentLookupDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public bool Accepted { get; set; }
        public bool? ForignTeacher { get; set; }
        public string MobileNumber { get; set; }
        public DateTime RegisterTime { get; set; }
        public int Age { get; set; }
        public double? Count { get; set; }

        public int? InsteadMobileNumber { get; set; }
    }
}
