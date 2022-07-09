using Incapsulation.Data.Entities;
using Incapsulation.Data.Specifications;

namespace Incapsulation.Data.Storages
{
    public class OrderStorage : DataStorage<Order>
    {
        public Order[] GetByDates(DateTime from, DateTime to)
        {
            var spec = new OrderByDatesSpecification(from, to);
            var result = GetBySpecification(spec);

            return result;
        }
        internal class OrderByDatesSpecification : SpecificationBase<Order>
        {
            private readonly DateTime _from;
            private readonly DateTime _to;

            public OrderByDatesSpecification(DateTime from, DateTime to)
            {
                _from = from;
                _to = to;
            }

            protected override bool CheckSpecification(Order order)
            {
                if (order.Created < _to && order.Created > _from)
                    return true;

                return false;
            }
        }
    }
}
