using Bogus;
using Bogus.Extensions.Sweden;
using BogusPlayground.Models;

namespace BogusPlayground;

public static class FakerFactory
{
    public static Faker<Customer> CreateCustomerFaker(int seed, string locale)
    {
        Randomizer.Seed = new Random(seed);
        
        var personFaker = new Faker<PersonIdentity>(locale)
            .CustomInstantiator(faker => 
            {
                var person = new Person(locale);
                return new PersonIdentity(
                    person.Personnummer(),
                    person.FirstName,
                    person.LastName
                );
            });

        var contactInfoFaker = new Faker<ContactInfo>(locale)
            .CustomInstantiator(f => new ContactInfo(
                f.Internet.Email(),
                f.Phone.PhoneNumber("07#-###-####")
            ));

        var addressFaker = new Faker<Address>(locale)
            .CustomInstantiator(f => new Address(
                f.Address.StreetAddress(),
                f.Address.City(),
                f.Address.ZipCode()
            ));

        var customerFaker = new Faker<Customer>()
            .CustomInstantiator(f => new Customer
            (
                Guid.NewGuid(),
                personFaker.Generate(),
                addressFaker.Generate(),
                contactInfoFaker.Generate()
            ))
            .FinishWith((f, c) => c.ContactInfo.Email = f.Internet.Email(c.PersonIdentity.FirstName, c.PersonIdentity.LastName));

        return customerFaker;
    }
}