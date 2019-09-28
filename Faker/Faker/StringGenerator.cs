using System;
using System.Collections.Generic;
using System.Text;

namespace Faker
{
    class StringGenerator : IGenerator
    {
        public object Generate()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var stringSize = random.Next(1, 50);
            var sb = new StringBuilder();
            for (int i = 0; i < stringSize; i++)
            {
                sb.Append(chars[i]);
            }
            return sb;
        }

        public Type GetObjectType()
        {
            return typeof(string);
        }
    }
}
