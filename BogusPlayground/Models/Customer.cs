namespace BogusPlayground.Models;

public class Customer
{
    public Guid Id { get; set; }
    public PersonIdentity PersonIdentity { get; set; }
    public Address Address { get; set; }
    public ContactInfo ContactInfo { get; set; }
    
}