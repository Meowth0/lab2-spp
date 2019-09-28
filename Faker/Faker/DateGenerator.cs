using System;
using System.Collections.Generic;
using System.Text;

namespace Faker
{
    class DateGenerator : IGenerator
    {
        public object Generate()
        {
            byte[] bytes = new byte[8];
            new Random().NextBytes(bytes);
            long ticks = BitConverter.ToInt64(bytes, 0);
            return new DateTime(Math.Abs(ticks % (DateTime.MaxValue.Ticks - DateTime.MinValue.Ticks)) + DateTime.MinValue.Ticks);
        }

        public Type GetObjectType()
        {
            return typeof(DateTime);
        }
    }
}
