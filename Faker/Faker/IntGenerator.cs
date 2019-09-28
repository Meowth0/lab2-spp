using System;
using System.Collections.Generic;
using System.Text;

namespace Faker
{
    class IntGenerator : IGenerator
    {
        public object Generate()
        {
            return new Random().Next(1, int.MaxValue);
        }

        public Type GetObjectType()
        {
            return typeof(int);
        }
    }
}
