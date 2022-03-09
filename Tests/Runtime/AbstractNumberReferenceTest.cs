using System;
using NUnit.Framework;
using Variables.unity_variables.Runtime;

namespace Variables.Tests
{
    public abstract class AbstractNumberReferenceTest<T, TV> : AbstractValueContainerTest<T, TV> 
        where TV : IMathOperations<T>
    {
        [Test]
        public void AssertInvOfConstant()
        {
            AssertInv();
        }
        
        [Test]
        public void AssertInvOfVariable()
        {
            AssertInv();
        }

        [Test]
        public void AssertIncOfConstant()
        {
            AssertInc();
        }
        
        [Test]
        public void AssertIncOfVariable()
        {
            AssertInc();
        }
        
        [Test]
        public void AssertDecOfConstant()
        {
            AssertDec();
        }
        
        [Test]
        public void AssertDecOfVariable()
        {
            AssertDec();
        }
        
        [Test]
        public void AssertAddOfConstant()
        {
            AssertAdd();
        }
        
        [Test]
        public void AssertAddOfVariable()
        {
            AssertAdd();
        }
        
        [Test]
        public void AssertSubOfConstant()
        {
            AssertSub();
        }
        
        [Test]
        public void AssertSubOfVariable()
        {
            AssertSub();
        }
        
        [Test]
        public void AssertMulOfConstant()
        {
            AssertMul();
        }
        
        [Test]
        public void AssertMulOfVariable()
        {
            AssertMul();
        }
        
        [Test]
        public void AssertDivOfConstant()
        {
            AssertDiv();
        }
        
        [Test]
        public void AssertDivOfVariable()
        {
            AssertDiv();
        }

        protected abstract T Inv(T value);
        protected abstract T Inc(T value);
        protected abstract T Dec(T value);
        protected abstract T Add(T value1, T value2);
        protected abstract T Sub(T value1, T value2);
        protected abstract T Mul(T value1, T value2);
        protected abstract T Div(T value1, T value2);

        private void AssertInv()
        {
            AssertOperation((reference, f) => reference.Inv(), (f1, f2) => Inv(f1));
        }

        private void AssertInc()
        {
            AssertOperation((reference, f) => reference.Inc(), (f1, f2) => Inc(f1));
        }

        private void AssertDec()
        {
            AssertOperation((reference, f) => reference.Dec(), (f1, f2) => Dec(f1));
        }

        private void AssertAdd()
        {
            AssertOperation((reference, f) => reference.Add(f), Add);
        }

        private void AssertSub()
        {
            AssertOperation((reference, f) => reference.Sub(f), Sub);
        }

        private void AssertMul()
        {
            AssertOperation((reference, f) => reference.Mul(f), Mul);
        }

        private void AssertDiv()
        {
            AssertOperation((reference, f) => reference.Div(f), Div);
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