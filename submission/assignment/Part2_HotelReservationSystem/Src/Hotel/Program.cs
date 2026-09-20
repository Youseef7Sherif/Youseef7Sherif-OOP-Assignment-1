namespace Hotel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var guest = new Guest(
                "Youssef Mohamed",
                "youssef@gmail.com",
                "01000000000");

            var room = new Room(
                101,
                RoomType.Double,
                1500);

            var manager = new ReservationManager();

            var reservation = manager.CreateReservation(
                DateTime.Today,
                DateTime.Today.AddDays(3),
                room,
                guest);

            Console.WriteLine($"Guest: {guest.FullName}");
            Console.WriteLine($"Room: {reservation.Room.RoomNumber}");
            Console.WriteLine($"Status: {reservation.Status}");
            Console.WriteLine($"Total: {reservation.Total}");

            reservation.Confirm();
            reservation.CheckIn();

            Console.WriteLine($"Status after check-in: {reservation.Status}");
            try
            {
                manager.CreateReservation(
                    DateTime.Today.AddDays(1),
                    DateTime.Today.AddDays(2),
                    room,
                    guest);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Expected error: {ex.Message}");
            }

            reservation.CheckOut();

            Console.WriteLine($"Final status: {reservation.Status}");
            
        }
    }
}