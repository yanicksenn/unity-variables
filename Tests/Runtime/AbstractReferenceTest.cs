using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;

namespace Variables.Tests
{
    public abstract class AbstractReferenceTest<T, TR, TV, TE> : AbstractSetterGetterTest<T, TR>
        where TV : AbstractVariable<T, TE>
        where TR : AbstractReference<T, TV, TE>
        where TE : UnityEvent<T>
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