using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.Data.Specifications
{
    //sealed - запечатанный
    //если попытаемся запечатать базовый(абстрактный) класс компилятор заругается,
    //потому что абстрактный класс должен иметь реализацию (это его природа - иметь наследников),
    //а sealed не позволяет реализовать т.к. запечатывает класс,
    //так же асбтрактный класс не может быть статическим.

    //часто встречающиеся ограничения для классов internal sealed -
    //это говорит о том, что дальнейшего расширения через наследование быть не должно!
    internal sealed class MyClass { }

}
