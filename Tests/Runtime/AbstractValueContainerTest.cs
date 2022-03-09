using NUnit.Framework;

namespace Variables.Tests
{
    public abstract class AbstractValueContainerTest<T>
    {
        protected abstract IValueContainer<T> CreateVariable();
        protected abstract T CreateRandomValue();
        
        [Test]
        public void AssertSetterGetterOfConstant()
        {
            var variable = CreateVariable();
            var expectedValue = CreateRandomValue();
            variable.SetValue(expectedValue);
            
            var actualValue = variable.GetValue();
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}