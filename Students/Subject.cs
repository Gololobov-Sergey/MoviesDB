using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        public List<Student> Students { get; set; } = new();

        public List<Exam> Exam { get; set; } = [];
    }
}
