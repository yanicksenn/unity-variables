using NUnit.Framework;
using UnityEngine;

namespace Variables.Tests
{
    public abstract class AbstractReferenceTest<T, TR, TV> : AbstractValueContainerTest<T, TR>
        where TV : AbstractVariable<T>
        where TR : AbstractReference<T, TV>
    {
        [Test]
        public void AssertSetterGetterOfVariable()
        {
            _valueContainer.Variable = CreateVariable();
            _valueContainer.UseConstant = false;
            
            var expectedValue = CreateRandomValue();
            _valueContainer.SetValue(expectedValue);
            
            var actualValue = _valueContainer.GetValue();
            Assert.AreEqual(expectedValue, actualValue);
            Assert.AreEqual(expectedValue, _valueContainer.Variable.GetValue());
        }
        
        private TV CreateVariable()
        {
            return ScriptableObject.CreateInstance<TV>();
        }
    }
}