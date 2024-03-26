using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Dapper.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public DateTime BirthDay { get; set; }

        public int GroupId { get; set; }

        //public Group? Group { get; set; }


        public int AddressId { get; set; }

        //public Address? Address { get; set; }


        public override string ToString()
        {
            return $"{Id}. {Name} {BirthDay.ToShortDateString()}";
        }
    }
}
