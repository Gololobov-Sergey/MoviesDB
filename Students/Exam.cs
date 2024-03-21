using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students
{
    public class Exam
    {
        public int Id { get; set; }

        public int StudentId {  get; set; }
        public Student Student { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public int Mark {  get; set; }


    }
}
