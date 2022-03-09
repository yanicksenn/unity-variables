using NUnit.Framework;
using UnityEngine;
using Variables.Bools;

namespace Variables.Tests.Bools
{
    public class BoolReferenceTest : AbstractReferenceTest<bool, BoolValueContainer, BoolReference>
    {
        [Test]
        public void AssertInvOfConstant()
        {
            var initialValue = CreateRandomValue();
            _reference.UseConstant = true;
            _reference.SetValue(initialValue);
            _reference.Inv();
            Assert.AreEqual(!initialValue, _reference.GetValue());
        }
        
        [Test]
        public void AssertInvOfVariable()
        {
            var initialValue = CreateRandomValue();
            _reference.UseConstant = false;
            _reference.SetValue(initialValue);
            _reference.Inv();
            Assert.AreEqual(!initialValue, _reference.GetValue());
            Assert.AreEqual(!initialValue, _variable.GetValue());
        }
        
        [Test]
        public void AssertTrueOfConstant()
        {
            var initialValue = CreateRandomValue();
            _reference.UseConstant = true;
            _reference.SetValue(initialValue);
            _reference.True();
            Assert.AreEqual(true, _reference.GetValue());
        }
        
        [Test]
        public void AssertTrueOfVariable()
        {
            var initialValue = CreateRandomValue();
            _reference.UseConstant = false;
            _reference.SetValue(initialValue);
            _reference.True();
            Assert.AreEqual(true, _reference.GetValue());
            Assert.AreEqual(true, _variable.GetValue());
        }
        
        [Test]
        public void AssertFalseOfConstant()
        {
            var initialValue = CreateRandomValue();
            _reference.UseConstant = true;
            _reference.SetValue(initialValue);
            _reference.False();
            Assert.AreEqual(false, _reference.GetValue());
        }
        
        [Test]
        public void AssertFalseOfVariable()
        {
            var initialValue = CreateRandomValue();
            _reference.UseConstant = false;
            _reference.SetValue(initialValue);
            _reference.False();
            Assert.AreEqual(false, _reference.GetValue());
            Assert.AreEqual(false, _variable.GetValue());
        }

        protected override BoolReference CreateReference()
        {
            return new BoolReference();
        }

        protected override BoolValueContainer CreateVariable()
        {
            return ScriptableObject.CreateInstance<BoolValueContainer>();
        }

        protected override bool CreateRandomValue()
        {
            return Random.Range(0, 1) == 0;
        }
    }
}