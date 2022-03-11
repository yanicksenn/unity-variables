using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Variables.Tests
{
    public abstract class AbstractValueContainerTest<T, TV> where TV : IValueContainer<T>
    {
        protected TV _valueContainer;

        [SetUp]
        public void SetUp()
        {
            _valueContainer = CreateValueContainer();
        }
        
        protected abstract TV CreateValueContainer();
        protected abstract T CreateRandomValue();

        protected T CreateRandomValueExcept(params T[] values)
        {
            var value = CreateRandomValue();
            while (values.Contains(value))
                value = CreateRandomValue();

            return value;
        }
    }
}