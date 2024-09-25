namespace ReservasParking.Models
{
    public class ReservationRegister
    {
        public int user_id { get; set; }
        public string entry_hour { get; set; }
        public string left_hour { get; set; }

        public int parking_id { get; set; }
    }
}
