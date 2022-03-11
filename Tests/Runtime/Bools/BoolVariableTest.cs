using NUnit.Framework;
using Tests;
using Variables.Bools;
using UnityEngine;

namespace Variables.Tests.Bools
{
    public class BoolVariableTest : AbstractSetterGetterTest<bool, BoolVariable>
    {
        private UnityEventListener _listener;

        [SetUp]
        public void AddListener()
        {
            _listener = new UnityEventListener("OnChange");
            _valueContainer.OnChangeEvent.AddListener(_listener.Invoke);
        }

        [Test]
        public void AssertOnChangeEventIsInvoked()
        {
            var newValue = !_valueContainer.GetValue();
            _valueContainer.SetValue(newValue);
            _listener.AssertInvocationsWithPayload(newValue, 1);
        }
        
        [Test]
        public void AssertOnChangeEventIsNotInvoked()
        {
            var newValue = _valueContainer.GetValue();
            _valueContainer.SetValue(newValue);
            _listener.AssertNoInvocationWithPayload(newValue);
        }

        protected override BoolVariable CreateValueContainer() => ScriptableObject.CreateInstance<BoolVariable>();
        protected override bool CreateRandomValue() => Random.Range(0, 1) == 0;
    }
}
