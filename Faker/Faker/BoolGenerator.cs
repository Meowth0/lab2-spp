using System;
using System.Collections.Generic;
using System.Text;

namespace Faker
{
    class BoolGenerator : IGenerator
    {
        public object Generate()
        {
            return true;
        }

        public Type GetObjectType()
        {
            return typeof(bool);
        }
    }
}
