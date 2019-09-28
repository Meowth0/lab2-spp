using System;
using System.Collections.Generic;
using System.Text;

namespace Faker
{
    class LongGenerator : IGenerator
    {
        public object Generate()
        {
            var random = new Random();
            var bytes = new byte[sizeof(Int64)];
            random.NextBytes(bytes);
            return BitConverter.ToInt64(bytes, 0);
        }

        public Type GetObjectType()
        {
            return typeof(long);
        }
    }
}
