//Урок 5 - полиморфизм
var result = DoSome(2);
var value = result;
Console.WriteLine(value);


static Result<int>? DoSome(int i)
{
    if (i == 0)
    {
        return new Result<int>()
        {
            Value = 0,
            IsSuccessful = false
        };
    }
    //if(i> 1)
    //{ return new Result<int>() { Value = i, IsSuccessful = true }; }
    if (i > 1)
        return i;

    return null;
}
//var a = new List<int>();
//Эта запись значит, что в переменной а будет содержаться список
//содержащий  в себе только целочисленные значения int

//int? a = 0; равнозначно > Nullable<double> b = 1;
#region InstanceClassesAnimal
//Экземпляр - Instance
//var animals = new List<Animal>()
//{
//    new Cat(){Name = "Barsik"},
//    new Dog(){Name = "Tuzik" }
//};

//var catFood = new AnimalFood() { Type = FoodType.CatFood, Brand = "Kitticat" };
//var dogFood = new AnimalFood() { Type = FoodType.DogFood, Brand = "Purina" };

//foreach (var animal in animals)
//{
//    animal.Feed(catFood);
//    animal.Feed(dogFood);
//}
//var i = 0;
////+i или -i - это применение унарного оператора к i.
//Console.WriteLine(+i);
////бинарные операторы + - * / | ^ &  < > <= >= (!= == - так же переопределяем Equals() and GetHashCode())

//Console.WriteLine(animals[0] + animals[1]);
#endregion


#region Animal
// Домашние приколы со статиками:
public class A
{
    public static int StaticValA { get; set; }
    public int ValA { get; set; }

    // Статический конструктор не может принимать параметры
    static A()
    {
        StaticValA = 10;
    }
    //публичный конструктор может принимать параметры
    public A(int val)
    {
        ValA = val;
    }
}
// неожиданна последовательность обхода
public class B : A
{
    public static int StaticValB { get; set; }
    public int ValB { get; set; }

    static B()
    {
        StaticValB = 10;
    }
    public B(int valA, int valB) : base(valA)
    {
        ValB = valB;
    }
}

public enum AnimalType
{
    Cat,
    Dog,
    Unknown,
    // Переопределение методов на животных
    SuperAnimal
}

public enum FoodType
{
    CatFood,
    DogFood
}
// Существует в DOT.NET оператор IComparable - позволяет сравнивать

//public abstract class Animal : IComparable<Animal>
//{
//    public int CompareTo(Animal? other)
//    {
//        throw new NotImplementedException();
//    }
//}
public abstract class Animal
{
    public string? Name { get; set; }
    public abstract AnimalType Type { get; }


    //если метод не абстрактный (abstract), а виртуальный (virtual) 
    //то нет необходимости прописывать реальзацию в каждый метод и
    //реализацию можно делать в базовом методе
    public virtual void Feed(AnimalFood food)
    {
        Console.WriteLine($"Пробуем накормить жифотное {Type} кормом: {food.Type}");
    }
    //Также реализацию можно наследовать, прописав в наследнике:
    //base.Feed(food);

    //public void Test() { }
    //public void Test(int i) { }
    //стандартную арифметику невозможно переопределить на существующих классах
    //    public static int operator +(int a, int b)
    //    {
    //        return a + b;
    //    }

    /// <summary>
    /// Переопределение оператора на примере 
    /// сложения двух типов животных и получение третьего
    /// </summary>
    /// <param name="a">экземплял первого животного</param>
    /// <param name="b">экземплял второго животного</param>
    /// <returns>результат сложения</returns>
    //public static AnimalType operator +(Animal a, Animal b)
    //{
    //    return AnimalType.SuperAnimal;
    //}
}

public class AnimalFood
{
    public FoodType Type { get; set; }
    public string? Brand { get; set; }
}

public class Cat : Animal
{
    public override AnimalType Type => AnimalType.Cat;

    public override void Feed(AnimalFood food)
    {
        if (food == null)
        {
            return;
        }
        if (food.Type == FoodType.DogFood)
        {
            Console.WriteLine("Неправильный тип еды для котёнка!");
        }
        if (food.Type == FoodType.CatFood)
        {
            Console.WriteLine("Котёнок будет счаслив!");
        }
    }
}

public class Dog : Animal
{
    public override AnimalType Type => AnimalType.Dog;

    public override void Feed(AnimalFood food)
    {
        if (food == null)
        {
            return;
        }
        if (food.Type == FoodType.CatFood)
        {
            Console.WriteLine("Неправильный тип еды для щенка!");
        }
        if (food.Type == FoodType.DogFood)
        {
            Console.WriteLine("Щенок будет счаслив!");
        }
    }
}
#endregion
class Result<T>
{
    // <T> - это генерик (тип обобщения)
    // генерик определяет расширяемый список
    public T? Value { get; set; }
    public bool IsSuccessful { get; set; }
    //implicit и explicit - не очень часто встречающиеся операторы
    public static implicit operator Result<T>(T value)
    {
        return new Result<T> { Value = value, IsSuccessful = true };
    }
    public static explicit operator T(Result<T> result)
    {
        return result.Value;
    }
}
//Урок 5 - полиморфизм конец основной части 5ой лекции.
//Далее возврат к 4ому занятию - DataStorage - переписывание на генерики.