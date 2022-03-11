using NUnit.Framework;
using Tests;
using Variables.Strings;
using UnityEngine;

namespace Variables.Tests.Strings
{
    public class StringVariableTest : AbstractSetterGetterTest<string, StringVariable>
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
        
        protected override StringVariable CreateValueContainer() => ScriptableObject.CreateInstance<StringVariable>();

        protected override string CreateRandomValue()
        {
            var length = Random.Range(5, 30);
            var chars = new char[length];
            for (var i = 0; i < length; i++)
            {
                var character = (char) Random.Range(65, 91);
                chars[i] = character;
            }

            return new string(chars);
        }
    }
}
