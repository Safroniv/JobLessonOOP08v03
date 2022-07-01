//Урок 4 - объекты, наследование, включает Incapsulation.Data
using Incapsulation.Data;
using Incapsulation.Data.Specifications;


var storage = new InMemoryCustomerDataStorage();
var newCastomer = storage.CreateCustomer(1, "Ivan", 37);

var cust = storage.GetById(10);
if (cust != null)
{
    cust.Name = "new name";
    _ = storage.UpdateCustomer(cust.Id, cust);

}
Console.WriteLine("ID: " + newCastomer.Id + "; Имя: " + newCastomer.Name + "; Лет: " + newCastomer.Age + ";");
Console.WriteLine("----------------------------------------------------------------------------------------");
var age10Spec = new CustomerByAgeSpecification(10);
var age10Customers = storage.GetBySpecification(age10Spec);

var age37Spec = new CustomerByAgeSpecification(37);
var age37Customers = storage.GetBySpecification(age37Spec);
Console.WriteLine(age10Customers.Length);
Console.WriteLine(age37Customers.Length);
Console.WriteLine("----------------------------------------------------------------------------------------");
//var abstractSpec = new SpecificationBase();
//при попытке создания экземпляра абстрактного класса - 
//не получается создать экземпляр абстрактного класса, ругается компилятор!
//у абстрактного класса нет instance (реализации).

//Чаще всего вместо абстрактных классов создаются интерфейсы.

//замена public Customer [] GetBySpecification (CustomerByAgeSpecification spec) 
//    на public Customer [] GetBySpecification (SpecificationBase spec)
// позволяет применять спеки разных типов

var nameSpec = new CustomerByNameSpecification("ivaN");
var customerByName = storage.GetBySpecification(nameSpec);

Console.WriteLine(customerByName.Length);