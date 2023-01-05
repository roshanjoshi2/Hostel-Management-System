namespace HMS.Models
{
    public class Hostel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public double Contact { get; set; }
        

        public int Capacity { get; set; }

        public int Rooms { get; set; }

        public int Seaters { get; set; }

        public int EmptySeats { get; set; }

        public float Fees{ get; set; }

        public List<Student> Students{ get; set; }

    }
}
