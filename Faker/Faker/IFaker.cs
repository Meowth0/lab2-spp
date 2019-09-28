using System;
using System.Collections.Generic;
using System.Text;

namespace Faker
{
    interface IFaker
    {
        object CreateObj<T>();
    }
}
