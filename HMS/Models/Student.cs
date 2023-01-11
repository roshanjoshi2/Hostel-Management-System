using System.ComponentModel.DataAnnotations.Schema;

namespace HMS.Models
{
    public class Student
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public float ContactNumber { get; set; }

        public string Email { get; set; }

        public double Cit { get; set; }


        //[NotMapped]
        //public IFormFile ProfileImage { get; set; }

        //public string StudentsProfileImagePath { get; set; }






        [ForeignKey("Hostels")]
        public int  HostelID { get; set; }

        public Hostel HostelName { get; set; }
    }
}
