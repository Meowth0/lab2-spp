using System;
using System.Collections.Generic;
using System.Text;

namespace Faker
{
    class ListGenerator<T> : IGenerator
    {
        public object Generate()
        {
            var list = new List<T>();
            var listSize = new Random().Next(1, 20);

            return list;
        }

        public Type GetObjectType()
        {
            return typeof(List<T>);
        }
    }
}
