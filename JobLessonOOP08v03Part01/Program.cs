//Урок 4 - объекты, наследование, включает Incapsulation.Data
//+ Урок 5 - переписывание DataStorage на генерики
using Incapsulation.Data.Entities;
using Incapsulation.Data.Specifications;
using Incapsulation.Data.Storages;

var customerStorage = new DataStorage<Customer>();
customerStorage.AddEntity(new Customer()
{
    Id = 1,
    Name = "Ivan",
    Age = 37
}); 

var cust = customerStorage.GetById(10);
if (cust != null)
{
    cust.Name = "new name";
    _ = customerStorage.UpdateCustomer(cust.Id, cust);

}
//доступ к полям из Storages
var orderStorage = new OrderStorage();


Console.WriteLine("----------------------------------------------------------------------------------------");
var age10Spec = new CustomerByAgeSpecification(10);
var age10Customers = customerStorage.GetBySpecification(age10Spec);

var age37Spec = new CustomerByAgeSpecification(37);
var age37Customers = customerStorage.GetBySpecification(age37Spec);
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
var customerByName = customerStorage.GetBySpecification(nameSpec);

Console.WriteLine(customerByName.Length);