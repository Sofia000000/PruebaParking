namespace ReservasParking.Models
{
    public class Reservation
    {

        public int Id { get; set; }
        public int user_id { get; set; }
        public TimeSpan entry_hour {  get; set; }
        public TimeSpan left_hour { get; set;}

        public int parking_id { get; set;}
    }
}
