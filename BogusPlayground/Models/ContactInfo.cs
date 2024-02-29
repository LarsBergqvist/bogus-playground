namespace BogusPlayground.Models;

public class ContactInfo
{
    public string Email { get; set; }
    public string Phone { get; set; }

    public ContactInfo(string email, string phone)
    {
        Email = email;
        Phone = phone;
    }
    
}