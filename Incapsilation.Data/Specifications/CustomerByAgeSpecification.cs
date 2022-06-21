namespace Incapsulation.Data.Specifications
{
    public class CustomerByAgeSpecification : SpecificationBase
    {
        private int _age;

        public CustomerByAgeSpecification(int specAge)
        {
            _age = specAge;
            _test = 115;
        }
        //override это реализация абстрактного метода в наследуемом классе
        //если добавить sealed - то мы запечатаем метод от наследования в дальнейшем
        protected sealed override bool CheckSpecification(Customer customer)
        {
            //return true; // это просто пока заглушка
            return customer.Age == _age;
        }

        public override void Test()
        {
            throw new NotImplementedException();
        }
    }
}
