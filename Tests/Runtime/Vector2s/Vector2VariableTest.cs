using NUnit.Framework;
using Tests;
using Variables.Vector2s;
using UnityEngine;

namespace Variables.Tests.Vector2s
{
    public class Vector2VariableTest : AbstractSetterGetterTest<Vector2, Vector2Variable>
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
        
        protected override Vector2Variable CreateValueContainer() => ScriptableObject.CreateInstance<Vector2Variable>();
        protected override Vector2 CreateRandomValue() => Random.insideUnitCircle;
    }
}
