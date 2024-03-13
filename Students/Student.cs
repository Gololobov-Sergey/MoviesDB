using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    //[Table("User")]
    public class Student
    {
        //[Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        //[Column("bd")]
        public DateOnly BirthDay { get; set; }



        public int GroupId { get; set; }

        public Group? Group { get; set; }



        public int AddressId { get; set; }

        public Address? Address { get; set; }



        [NotMapped]
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{Id}. {Name} {BirthDay.ToShortDateString()}";
        }
    }
}
