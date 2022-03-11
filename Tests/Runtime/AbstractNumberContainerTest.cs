using System;
using NUnit.Framework;
using Variables.Runtime;

namespace Variables.Tests
{
    public abstract class AbstractNumberContainerTest<T, TV> : AbstractValueContainerTest<T, TV> 
        where TV : INumberContainer<T>
    {
        [Test]
        public void AssertInv() => AssertOperation((reference, f) => reference.Inv(), Inv);

        [Test]
        public void AssertInc() => AssertOperation((reference, f) => reference.Inc(), Inc);

        [Test]
        public void AssertDec() => AssertOperation((reference, f) => reference.Dec(), Dec);

        [Test]
        public void AssertAdd() => AssertOperation((reference, f) => reference.Add(f), Add);

        [Test]
        public void AssertSub() => AssertOperation((reference, f) => reference.Sub(f), Sub);

        [Test]
        public void AssertMul() => AssertOperation((reference, f) => reference.Mul(f), Mul);

        [Test]
        public void AssertDiv() => AssertOperation((reference, f) => reference.Div(f), Div);

        protected abstract T Inv(T value);
        protected abstract T Inc(T value);
        protected abstract T Dec(T value);
        protected abstract T Add(T value1, T value2);
        protected abstract T Sub(T value1, T value2);
        protected abstract T Mul(T value1, T value2);
        protected abstract T Div(T value1, T value2);

        
        private void AssertOperation(Action<TV, T> action, Func<T, T> expectation)
        {
            var initialValue = CreateRandomValue();
            _valueContainer.SetValue(initialValue);

            var randomValue = CreateRandomValue();
            action.Invoke(_valueContainer, randomValue);

            var expectedValue = expectation.Invoke(initialValue);
            Assert.AreEqual(expectedValue, _valueContainer.GetValue());
        }
        
        private void AssertOperation(Action<TV, T> action, Func<T, T, T> expectation)
        {
            var initialValue = CreateRandomValue();
            _valueContainer.SetValue(initialValue);

            var randomValue = CreateRandomValue();
            action.Invoke(_valueContainer, randomValue);

            var expectedValue = expectation.Invoke(initialValue, randomValue);
            Assert.AreEqual(expectedValue, _valueContainer.GetValue());
        }
    }
}