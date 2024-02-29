using System.Text.Json;
using System.Text.Unicode;
using BogusPlayground;

var customerFaker = FakerFactory.CreateCustomerFaker(127893, "sv");

var jsonOptions = new JsonSerializerOptions
{
    WriteIndented = true,
    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All)
};

for(var i=0; i < 25; i++)
{
    var customer = customerFaker.Generate();
//    Console.WriteLine($"{customer.PersonIdentity.FirstName} {customer.PersonIdentity.Personnummer}");
//    var gender = (customer.PersonIdentity.Personnummer[10] - '0') % 2 == 0 ? "Female" : "Male";
//    Console.WriteLine($"{customer.PersonIdentity.FirstName}, {gender}");
    var json = JsonSerializer.Serialize(customer, jsonOptions);
    Console.WriteLine(json);
}
