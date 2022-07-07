using Incapsulation.Data.Entities;

namespace Incapsulation.Data.Specifications
{
    public abstract class SpecificationBase<TEntity> where TEntity : BaseEntity
    {
        //Вводим понятие абстрактного класса
        //Абстрактный класс - это класс для вынесения общей функциональности,
        //возможно даже с какаой-то общей реализацией,
        //но у абстрактного класса есть особенность - нельзя создать его экземпляр.
        //Чаще всего вместо абстрактных классов создаются интерфейсы.
        //protected int _test;
        //protected - это поле, метод, свойство доступное классу и его наследникам
        //но не доступна извне.
        //public SpecificationBase()
        //{
        //    _test = 112;
        //}

        public bool Ensure(TEntity entity)
        {
            if (entity == null)
            {
                return false;
            }
            return CheckSpecification(entity);
        }

        protected abstract bool CheckSpecification(TEntity entity);

        //Абстактный класс даёт обязаловку - 
        //реализовать все абастрактные методы объявленные в абстрактном классе
        // Если класс не абстрактный
        // и в классе мы оъявляем абстрактный метод,
        // то класс автоматом становится абстрактным
        // и нужно объявлять его абстрактным иначе методы начинают ругаться.

        //в абстрактном классе могут быть объявлены разные методы
        //и private и protected и abstract методы и поля
        //но если в обычном методе объявлен абстрактный метод или свойство
        //(поле не может быть абстракт - не имеет смысла)

        //public abstract void Test();

    }
}
