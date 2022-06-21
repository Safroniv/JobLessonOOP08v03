namespace Incapsilation.Data.Specifications
{
    //Если отнаследоваться от наследованного метода 
    //можно ли сделать перегрузку перегруженного метода - да можно но нестоит!
    //пример:
    public class CustomerByTwoNamesSpecification : CustomerByNameSpecification
    {
        private string _secondName;

        public CustomerByTwoNamesSpecification(string specName, string specSecondName) : base(specName)
        {
            _secondName = specSecondName;
        }
        protected override bool CheckSpecification(Customer customer)
        {
            var specByNameResult = base.CheckSpecification(customer);
            return specByNameResult
                && string.Compare(customer.Name, _secondName, StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}
