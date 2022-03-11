using NUnit.Framework;
using Tests;
using Variables.Vector3s;
using UnityEngine;

namespace Variables.Tests.Vector3s
{
    public class Vector3VariableTest : AbstractSetterGetterTest<Vector3, Vector3Variable>
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
            var newValue = CreateRandomValueExcept(_valueContainer.GetValue());
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
        
        protected override Vector3Variable CreateValueContainer() => ScriptableObject.CreateInstance<Vector3Variable>();
        protected override Vector3 CreateRandomValue() => Random.insideUnitCircle;
    }
}
