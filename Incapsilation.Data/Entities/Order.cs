using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.Data.Entities
{
    public class Order : BaseEntity
    {
        //Кроме кастомеров появляется новая сущность - ЗАКАЗ
        public DateTime Created { get; set; }
        public Customer? Customer { get; set; }

    }
}
