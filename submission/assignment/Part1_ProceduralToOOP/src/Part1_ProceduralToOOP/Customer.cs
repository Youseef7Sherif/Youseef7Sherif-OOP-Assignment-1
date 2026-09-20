namespace Part1_ProceduralToOOP;

public class Customer
{
    public string Name { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public Guid Id { get; }
    public string City { get; private set; }

    public bool IsVip { get; private set; }

    public Customer(string name, string email, string phoneNumber, string city, bool isVip)
    {
        if(string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be null or empty.", nameof(name));
        }
        if(string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email cannot be null or empty.", nameof(email));
        }
        if(string.IsNullOrWhiteSpace(phoneNumber))
        {
            throw new ArgumentException("PhoneNumber cannot be null or empty.", nameof(phoneNumber));
        }
        if(string.IsNullOrWhiteSpace(city))
        {
            throw new ArgumentException("City cannot be null or empty.", nameof(city));
        }
       

        Id = Guid.NewGuid();
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        City = city;
        IsVip = isVip;
    }





}

