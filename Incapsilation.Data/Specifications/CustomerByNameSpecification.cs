using Incapsulation.Data.Entities;

namespace Incapsulation.Data.Specifications
{
    public class CustomerByNameSpecification : SpecificationBase<Customer>
    {
        private string _name;

        public CustomerByNameSpecification(string specName)
        {
            _name = specName;

        }
        protected override bool CheckSpecification(Customer customer)
        {
            //return true; // это просто пока заглушка
            return string.Compare(customer.Name, _name, StringComparison.OrdinalIgnoreCase) == 0;
            //OrdinalIgnoreCase позволяет name Ivan и ivaN - считать одинаковыми 
        }

        public override void Test()
        {
            throw new NotImplementedException();
        }
    }
}
