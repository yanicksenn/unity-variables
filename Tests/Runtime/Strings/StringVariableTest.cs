using CraipaiGames.Variables.Strings;
using JetBrains.Annotations;
using UnityEngine;

namespace CraipaiGames.Variables.Tests.Strings
{
    [UsedImplicitly]
    public class StringVariableTest : AbstractVariableTest<string>
    {
        protected override AbstractVariable<string> CreateVariable() => ScriptableObject.CreateInstance<StringVariable>();

        protected override string GetValue() => "Test";
    }
}
