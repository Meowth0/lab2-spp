using System;
using System.Collections.Generic;
using System.Text;

namespace Faker
{
    interface IGenerator
    {
        object Generate();

        Type GetObjectType();
    }
}
