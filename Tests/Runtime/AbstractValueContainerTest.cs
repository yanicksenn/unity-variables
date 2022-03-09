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
        
        [Test]
        public void AssertSetterGetter()
        {
            var expectedValue = CreateRandomValue();
            _valueContainer.SetValue(expectedValue);
            
            var actualValue = _valueContainer.GetValue();
            Assert.AreEqual(expectedValue, actualValue);
        }
        
        protected abstract TV CreateValueContainer();
        protected abstract T CreateRandomValue();
    }
}