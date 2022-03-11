using Variables.Quaternions;
using JetBrains.Annotations;
using NUnit.Framework;
using Tests;
using UnityEngine;

namespace Variables.Tests.Quaternions
{
    [UsedImplicitly]
    public class QuaternionVariableTest : AbstractSetterGetterTest<Quaternion, QuaternionVariable>
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
        
        protected override QuaternionVariable CreateValueContainer() => ScriptableObject.CreateInstance<QuaternionVariable>();
        protected override Quaternion CreateRandomValue() => Random.rotation;
    }
}
