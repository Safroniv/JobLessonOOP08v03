using Incapsulation.Data.Specifications;

namespace Incapsulation.Data
{
    public class InMemoryCustomerDataStorage
    {
        private Dictionary<int, Customer> _data = new Dictionary<int, Customer>();

        //crud - сreate read update delete

        /// <summary>
        /// Create customer
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public Customer CreateCustomer(int id, string name, int age)
        {
            var customer = new Customer
            {
                Id = id,
                Name = name,
                Age = age
            };
            _data.Add(id, customer);
            return customer;
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Customer? GetById(int id)
        {
            var result = _data.TryGetValue(id, out var customer);
            return result == false ? null : customer;
        }

        //было
        //public Customer[] GetBySpecification (CustomerByAgeSpecification spec)

        public Customer[] GetBySpecification(SpecificationBase spec)
        {
            var allCustomers = _data.Values.ToArray();
            var result = new List<Customer>();
            //когда применяется конструкция с массивом,
            //мы говорим что для каждого элемента данного массива
            //мы производим перебор элементов
            foreach (var customer in allCustomers)
            {
                if (spec.Ensure(customer))
                {
                    result.Add(customer);
                }
            }
            return result.ToArray();
        }

        /// <summary>
        /// Update customer
        /// </summary>
        /// <returns></returns>
        public bool UpdateCustomer(int id, Customer updateCustomer)
        {
            if (_data.TryGetValue(id, out var _))
            {
                _data[id] = updateCustomer;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete customer
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteCustomer(int id)
        { return _data.Remove(id); }
    }
}
