// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using BogusPlayground;

var customerFaker = FakerFactory.CreateCustomerFaker(127893, "sv");

for(var i=0; i < 15; i++)
{
    var customer = customerFaker.Generate();
//    Console.WriteLine($"{customer.PersonIdentity.FirstName} {customer.PersonIdentity.Personnummer}");
    var json = JsonSerializer.Serialize(customer);
    Console.WriteLine(json);
}
