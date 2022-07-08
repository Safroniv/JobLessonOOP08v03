//Урок 6 - наследование и полиморфизм часть 1 (0:47:54)

//new Foo(); - работать не будет - вычистится раньше запуска консоли

var foo = new Foo();
Console.WriteLine(foo is Foo);
//работать будет и вычистится самое раннее после консоли

//Foo foo = new Foo(); внутри всё равно наследник (0:33:12)
//Console.WriteLine(foo is Foo);

foo = null;

Thread.Sleep(1000);
GC.Collect(2, GCCollectionMode.Forced, true);

class Foo 
{
    public void Test()
    {
        //using var stream = new MemoryStream();
        //это синтаксический сахал, который разворачивается в:        
        //var stream = new MemoryStream();
        //try{}       
        //finally
        //{ stream.Dispose();}
    }
    //~Foo()
    //{
    //    Console.WriteLine("Disposed");
    //}
    //public override void Finalize()
    //{
    //}
}
//interface Foo2{}
//Деструктры - это которая выззывается при освобождении памяти
//занимаемой объектом (история про сборку мусора). они почти не встречаются.
