using System;
using NUnit.Framework;
using Variables.unity_variables.Runtime;

namespace Variables.Tests
{
    public abstract class AbstractNumberReferenceTest<T, TV, TR> : AbstractReferenceTest<T, TV, TR> 
        where TV : AbstractVariable<T>, IMathOperations<T>
        where TR : AbstractReference<T, TV>, IMathOperations<T>
    {
        [Test]
        public void AssertInvOfConstant()
        {
            AssertInv(true);
        }
        
        [Test]
        public void AssertInvOfVariable()
        {
            AssertInv(false);
        }

        [Test]
        public void AssertIncOfConstant()
        {
            AssertInc(true);
        }
        
        [Test]
        public void AssertIncOfVariable()
        {
            AssertInc(false);
        }
        
        [Test]
        public void AssertDecOfConstant()
        {
            AssertDec(true);
        }
        
        [Test]
        public void AssertDecOfVariable()
        {
            AssertDec(false);
        }
        
        [Test]
        public void AssertAddOfConstant()
        {
            AssertAdd(true);
        }
        
        [Test]
        public void AssertAddOfVariable()
        {
            AssertAdd(false);
        }
        
        [Test]
        public void AssertSubOfConstant()
        {
            AssertSub(true);
        }
        
        [Test]
        public void AssertSubOfVariable()
        {
            AssertSub(false);
        }
        
        [Test]
        public void AssertMulOfConstant()
        {
            AssertMul(true);
        }
        
        [Test]
        public void AssertMulOfVariable()
        {
            AssertMul(false);
        }
        
        [Test]
        public void AssertDivOfConstant()
        {
            AssertDiv(true);
        }
        
        [Test]
        public void AssertDivOfVariable()
        {
            AssertDiv(false);
        }

        protected abstract T Inv(T value);
        protected abstract T Inc(T value);
        protected abstract T Dec(T value);
        protected abstract T Add(T value1, T value2);
        protected abstract T Sub(T value1, T value2);
        protected abstract T Mul(T value1, T value2);
        protected abstract T Div(T value1, T value2);

        private void AssertInv(bool useConstant)
        {
            AssertOperation(useConstant, (reference, f) => reference.Inv(), (f1, f2) => Inv(f1));
        }

        private void AssertInc(bool useConstant)
        {
            AssertOperation(useConstant, (reference, f) => reference.Inc(), (f1, f2) => Inc(f1));
        }

        private void AssertDec(bool useConstant)
        {
            AssertOperation(useConstant, (reference, f) => reference.Dec(), (f1, f2) => Dec(f1));
        }

        private void AssertAdd(bool useConstant)
        {
            AssertOperation(useConstant, (reference, f) => reference.Add(f), Add);
        }

        private void AssertSub(bool useConstant)
        {
            AssertOperation(useConstant, (reference, f) => reference.Sub(f), Sub);
        }

        private void AssertMul(bool useConstant)
        {
            AssertOperation(useConstant, (reference, f) => reference.Mul(f), Mul);
        }

        private void AssertDiv(bool useConstant)
        {
            AssertOperation(useConstant, (reference, f) => reference.Div(f), Div);
        }
        
        private void AssertOperation(bool useConstant, Action<TR, T> action, Func<T, T, T> expectation)
        {
            var initialValue = CreateRandomValue();
            _reference.UseConstant = useConstant;
            _reference.SetValue(initialValue);
            
            var randomValue = CreateRandomValue();
            action.Invoke(_reference, randomValue);

            var expectedValue = expectation.Invoke(initialValue, randomValue);
            Assert.AreEqual(expectedValue, _reference.GetValue());
            
            if (!useConstant)
                Assert.AreEqual(expectedValue, _variable.GetValue());
        }
    }
}