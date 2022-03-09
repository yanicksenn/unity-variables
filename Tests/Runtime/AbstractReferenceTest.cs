using NUnit.Framework;

namespace Variables.Tests
{
    public abstract class AbstractReferenceTest<T, TV, TR> where TV : AbstractValueContainer<T> where TR : AbstractReference<T, TV>
    {
        protected TR _reference;
        protected TV _variable;
        
        [SetUp]
        public void SetUp()
        {
            _reference = CreateReference();
            _variable = CreateVariable();
            _reference.Variable = _variable;
        }

        [Test]
        public void AssertSetterGetterOfConstant()
        {
            var expectedValue = CreateRandomValue();
            _reference.UseConstant = true;
            _reference.SetValue(expectedValue);
            var actualValue = _reference.GetValue();
            Assert.AreEqual(expectedValue, actualValue);
        }
        
        [Test]
        public void AssertSetterGetterOfVariable()
        {
            var expectedValue = CreateRandomValue();
            _reference.UseConstant = false;
            _reference.SetValue(expectedValue);
            var actualValue = _reference.GetValue();
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedValue, _variable.GetValue());
        }

        protected abstract TR CreateReference();
        protected abstract TV CreateVariable();
        protected abstract T CreateRandomValue();
    }
}