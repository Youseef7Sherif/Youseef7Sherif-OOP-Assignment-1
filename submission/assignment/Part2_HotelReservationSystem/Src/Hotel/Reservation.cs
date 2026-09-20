namespace Hotel;

public class Reservation
{
    public Guid ReservationId { get; }
    public DateTime CheckInDate { get; }
    public DateTime CheckOutDate { get; }
    public Room Room { get; }
    public ReservationStatus Status { get; private set; }

    public Reservation(
        DateTime checkInDate,
        DateTime checkOutDate,
        Room room)
    {
        if (room == null)
        {
            throw new ArgumentNullException(
                nameof(room),
                "Room cannot be null.");
        }

        if (room.IsUnderMaintenance)
        {
            throw new InvalidOperationException(
                "Cannot reserve a room that is under maintenance.");
        }

        if (checkInDate >= checkOutDate)
        {
            throw new ArgumentException(
                "Check-in date must be before check-out date.");
        }

        ReservationId = Guid.NewGuid();
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        Room = room;
        Status = ReservationStatus.Pending;
    }

    public decimal Total =>
        (CheckOutDate - CheckInDate).Days * Room.NightlyRate;

    public void Confirm()
    {
        if (Status != ReservationStatus.Pending)
        {
            throw new InvalidOperationException(
                "Only pending reservations can be confirmed.");
        }

        Status = ReservationStatus.Confirmed;
    }

    public void CheckIn()
    {
        if (Status != ReservationStatus.Confirmed)
        {
            throw new InvalidOperationException(
                "Only confirmed reservations can be checked in.");
        }

        Status = ReservationStatus.CheckedIn;
    }

    public void CheckOut()
    {
        if (Status != ReservationStatus.CheckedIn)
        {
            throw new InvalidOperationException(
                "Only checked-in reservations can be checked out.");
        }

        Status = ReservationStatus.CheckedOut;
    }

    public void Cancel()
    {
        if (Status == ReservationStatus.Pending ||
            Status == ReservationStatus.Confirmed)
        {
            Status = ReservationStatus.Cancelled;
        }
        else
        {
            throw new InvalidOperationException(
                "Only pending or confirmed reservations can be cancelled.");
        }
    }
}