namespace Hotel;

public class Room
{
    public int RoomNumber { get; }
    public RoomType RoomType { get; }
    public decimal NightlyRate { get; private set; }
    public bool IsUnderMaintenance { get; private set; }

    public Room(int roomNumber, RoomType roomType, decimal nightlyRate)
    {
        if (roomNumber <= 0)
        {
            throw new ArgumentException(
                "Room number must be a positive integer.",
                nameof(roomNumber));
        }

        if (nightlyRate <= 0)
        {
            throw new ArgumentException(
                "Nightly rate cannot be zero or negative.",
                nameof(nightlyRate));
        }

        RoomNumber = roomNumber;
        RoomType = roomType;
        NightlyRate = nightlyRate;
    }

    public void StartMaintenance()
    {
        IsUnderMaintenance = true;
    }

    public void EndMaintenance()
    {
        IsUnderMaintenance = false;
    }

    public void UpdateNightlyRate(decimal newRate)
    {
        if (newRate <= 0)
        {
            throw new ArgumentException(
                "Nightly rate cannot be zero or negative.",
                nameof(newRate));
        }

        NightlyRate = newRate;
    }
}

