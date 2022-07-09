//Урок 6 - наследование и полиморфизм часть 2 (0:47:54+)

#region реализация наследуемых классов
//Foo barAsFoo = new Bar();
//var bar = new Bar();

//Console.WriteLine("++++++++ запуск bar и его методов ++++++++++");
//bar.Test();
//bar.NewTest();
//Console.WriteLine("++++++++ запуск bar через foo ++++++++");
//barAsFoo.Test();
//barAsFoo.NewTest(); //(0:56:10)
#endregion

#region реализация абстрактного класса
IBar6_2 test1  = new Test6_2();

test1.Test();

IFoo6_2 test2 = new Test6_2();
test2.Test();

#endregion
class Foo6_1
{
    public virtual void Test() 
    {
        Console.WriteLine("test base");
    }
    public virtual void NewTest()
    {
        Console.WriteLine("new test base");
    }
}

class Bar6_1 : Foo6_1
{
    public override void Test()
    {
        
        Console.WriteLine("test");
    }
    public new void NewTest()
    {
        Console.WriteLine("new test");
    }
}


//Eqals() и GetHashCode() - (0:59:01)
//Интерфейсы Interface(1:01:38+)
//интерфейс - это задание опредленного контракта,
//который должен реализовать класс
//отличие интерфейса от абстрактного класса
//с абстрактным классом можно указать все методы астрактными 
//но это будет урезанный интерфейс
//интерфейс - это набор методов который должен реализовать класс наследник
//интерфейсы Interface принято обозначать "I" -
//то есть Interface - IEntity IOrder

public interface IFoo6_2
{
    //public int Value { get; set; }
    //void Foo6_2();
    //с определенной версии шарпа появилась имплементация по умолчанию
    //и можно сделать так:
    //public int Value { get; set; } 
    public void Test();
    public int GetValue();
    //если у интерфейса много реализации по умолчанию,
    //задумайтесь не должен ли быть этот интерфейс быть абспрактным классом
}

public interface IBar6_2
{
    public void Test();
}
//отличие интерфейсов от абстракных классов, то,
//что интерфесы позволяют делать множественное наследование
//от класса абстрактного или нет, мы можем отнаследоваться только от одного
//вместе с тем интерфейсы это не наследование, а выполнение какого-то контракта
//то и имплементировать классы могут множество интерфейсов

public abstract class Bar6_2
{
    public abstract void Test();
}


//Интерфейсы работают только с методами,
//то есть ни какого состояния они хранить не могут
//что это значит, например:

public abstract class Foo6_2
{
    protected int _value;

    public int GetValue()
    {
        return _value;
    }
}
//и всё будет работать
//интерфейсы это не совсем наследование
//это интструмент, который жестко задаёт контракт

//в абстрактных классах мы можем методом,
//который мы не помечаем как abstract,
//можно давать имплементацию по умолчанию

public class Test6_2 : Bar6_2, IFoo6_2, IBar6_2
{
    //при реализации интерфейса возможно множественное наследование
    //по этому класс может быть и IFoo и IBar и потом даже Bar
    //можно имплементировать только один класс и сколько угодно интерфейсов
    //базовый класс всегда идёт перед интерфейсами
    public int Value { get; set; } = 10;
    //всегда должна быть какая-нибудь реализация интерфейса
    public int GetValue()
    { return Value; }

    public override void Test()
    {
        throw new NotImplementedException();
    }

    public void TestIBar()
    {
        throw new NotImplementedException();
    }
    void IBar6_2.Test()
    {
        Console.WriteLine("Test IBar from class");
    }
    void IFoo6_2.Test()
    {
        Console.WriteLine("Test IFoo from class");
    }
}
//Есть паттерн стратегия strategy,
//когда мы не знаем какой тип нам будет нужен на этапе компиляции
//интерфейсы чаще всего стараются делать довольно небольшими
//и врамках одной задачи.
//в программе не должно быть гигантских которые покрывать всю программу
//по интерфейсу должно быть понятно ЧТО именно будет делать класс
 
