using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class Address
    {
        public int Id { get; set; }

        public string? Country { get; set; }

        public string? City { get; set; }

        public List<Student> Students { get; set; } = new();
    }
}
