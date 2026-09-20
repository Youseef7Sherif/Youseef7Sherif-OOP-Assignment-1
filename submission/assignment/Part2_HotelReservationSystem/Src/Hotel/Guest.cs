namespace Hotel;

public class Guest
{
    public Guid GuestId { get; }
    public string FullName { get; }
    public string Email { get; }
    public string PhoneNumber { get; }

    private List<Reservation> _reservations = new List<Reservation>();

    public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

    public Guest(string name, string email, string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException(
                "FullName cannot be null or empty.",
                nameof(name));
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException(
                "Email cannot be null or empty.",
                nameof(email));
        }

        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            throw new ArgumentException(
                "PhoneNumber cannot be null or empty.",
                nameof(phoneNumber));
        }

        GuestId = Guid.NewGuid();
        FullName = name;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public void AddReservation(Reservation reservation)
    {
        if (reservation == null)
        {
            throw new ArgumentNullException(
                nameof(reservation),
                "Reservation cannot be null.");
        }

        _reservations.Add(reservation);
    }

    public void RemoveReservation(Reservation reservation)
    {
        if (reservation == null)
        {
            throw new ArgumentNullException(
                nameof(reservation),
                "Reservation cannot be null.");
        }

        _reservations.Remove(reservation);
    }
}