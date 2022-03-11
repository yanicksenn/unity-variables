using NUnit.Framework;

namespace Variables.Tests
{
    public abstract class AbstractSetterGetterTest<T, TV> : AbstractValueContainerTest<T, TV> 
        where TV : IValueContainer<T>
    {
        [Test]
        public void AssertSetterGetter()
        {
            var expectedValue = CreateRandomValue();
            _valueContainer.SetValue(expectedValue);
            
            var actualValue = _valueContainer.GetValue();
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}