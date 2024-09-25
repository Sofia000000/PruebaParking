using Microsoft.AspNetCore.Mvc;
using ReservasParking.Data;
using ReservasParking.Models;

namespace ReservasParking.Controllers
{

    [Route("api/reservations")]
    [ApiController]
    public class ReservationController : Controller
    {
        private readonly ParkingDBContext _context;
        
        public ReservationController(ParkingDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult get(int id)
        {
            var result = _context.tbl_reservations.Find(id);

            if (result == null)
                return new JsonResult(NotFound());
            return new JsonResult(Ok(result));
        }

        [HttpGet("getall")]
        public JsonResult getall()
        {
            var reservations = _context.tbl_reservations.ToList();

            return new JsonResult(reservations);
        }


        [HttpPost]
        public JsonResult post([FromBody] ReservationRegister reservationRegister)
        {

            var newReservation = new Reservation { user_id = reservationRegister.user_id, entry_hour = TimeSpan.Parse(reservationRegister.entry_hour), left_hour = TimeSpan.Parse(reservationRegister.left_hour), parking_id = reservationRegister.parking_id };

            _context.tbl_reservations.Add(newReservation);

            _context.SaveChanges();

            return new JsonResult(Ok(newReservation));
        }
    }
}
