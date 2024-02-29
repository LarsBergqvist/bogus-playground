namespace BogusPlayground.Models;

public class Customer
{
    public Guid Id { get; }
    public PersonIdentity PersonIdentity { get; }
    public Address Address { get; }
    public ContactInfo ContactInfo { get; }

    public Customer(Guid id, PersonIdentity personIdentity, Address address, ContactInfo contactInfo)
    {
        Id = id;
        PersonIdentity = personIdentity;
        Address = address;
        ContactInfo = contactInfo;
    }
}