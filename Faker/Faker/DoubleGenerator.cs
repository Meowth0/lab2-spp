using System;
using System.Collections.Generic;
using System.Text;

namespace Faker
{
    class DoubleGenerator : IGenerator
    {
        public object Generate()
        {
            var random = new Random();
            double result;
            do
            {
                result = random.NextDouble();
            } while (Math.Abs(result - 0) < 0.0000001);
            return random.NextDouble();
        }

        public Type GetObjectType()
        {
            return typeof(double);
        }
    }
}
