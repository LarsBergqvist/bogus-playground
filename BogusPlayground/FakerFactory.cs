using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Sweden;
using BogusPlayground.Models;
using Address = BogusPlayground.Models.Address;

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
                var personPnr = new Person(locale);
                // Fixup for incorrect gender handling
                // in Bogus.Extensions.Sweden
                if (person.Gender == Name.Gender.Male)
                {
                    personPnr.Gender = Name.Gender.Female;
                }
                else
                {
                    personPnr.Gender = Name.Gender.Male;
                }
                return new PersonIdentity(
                    personPnr.Personnummer(),
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