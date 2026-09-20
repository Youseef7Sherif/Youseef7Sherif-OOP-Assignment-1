namespace Hotel;

public class ReservationManager
{
    private List<Reservation> _reservations = new List<Reservation>();

    public IReadOnlyList<Reservation> Reservations =>
        _reservations.AsReadOnly();

    private void AddReservation(Reservation reservation)
    {
        if (reservation == null)
        {
            throw new ArgumentNullException(
                nameof(reservation),
                "Reservation cannot be null.");
        }

        _reservations.Add(reservation);
    }

    private void ValidateNoOverlap(
        DateTime checkInDate,
        DateTime checkOutDate,
        Room room)
    {
        foreach (var existingReservation in _reservations)
        {
            if (existingReservation.Status == ReservationStatus.Cancelled ||
                existingReservation.Status == ReservationStatus.CheckedOut)
            {
                continue;
            }

            if (existingReservation.Room.RoomNumber == room.RoomNumber &&
                !(existingReservation.CheckOutDate < checkInDate) &&
                !(checkOutDate < existingReservation.CheckInDate))
            {
                throw new InvalidOperationException(
                    "The room is already booked for the selected dates.");
            }
        }
    }

    public Reservation CreateReservation(
        DateTime checkInDate,
        DateTime checkOutDate,
        Room room,
        Guest guest)
    {
        if (guest == null)
        {
            throw new ArgumentNullException(
                nameof(guest),
                "Guest cannot be null.");
        }

        ValidateNoOverlap(
            checkInDate,
            checkOutDate,
            room);

        var reservation = new Reservation(
            checkInDate,
            checkOutDate,
            room);

        AddReservation(reservation);
        guest.AddReservation(reservation);

        return reservation;
    }
}