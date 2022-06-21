//Урок 5 - полиморфизм

var animals = new List<Animal>()
{
    new Cat(){Name = "Barsik"},
    new Dog(){Name = "Tuzik" }
};

var catFood = new AnimalFood() { Type = FoodType.CatFood, Brand = "Kitticat" };
var dogFood = new AnimalFood() { Type = FoodType.DogFood, Brand = "Purina"  };

foreach (var animal in animals)
{
    animal.Feed(catFood);
    animal.Feed(dogFood);
}

public enum AnimalType
{
    Cat,
    Dog,
    Unknown
}

public enum FoodType
{
    CatFood,
    DogFood
}
public abstract class Animal
{
    public string? Name { get; set; }
    public abstract AnimalType Type { get; }
    public abstract void Feed(AnimalFood food);

}
//если метод не абстрактный (abstract), а виртуальный (virtual) 
//то нет необходимости прописывать реальзацию в каждый метод и
//реализацию можно делать в базовом методе
//public virtual void Feed(AnimalFood food)
//{
//    Console.WriteLine($"Пробуем накормить жифотное {Type} кормом: {food.Type}");
//}
//Также реализацию можно наследовать, прописав в наследнике:
//base.Feed(food);

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
        if(food.Type ==FoodType.DogFood)
        {
            Console.WriteLine("Неправильный тип еды для котёнка!");
        }
        if(food.Type ==FoodType.CatFood)
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