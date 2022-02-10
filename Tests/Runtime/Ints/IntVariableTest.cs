using CraipaiGames.Variables.Ints;
using JetBrains.Annotations;
using UnityEngine;

namespace CraipaiGames.Variables.Tests.Ints
{
    [UsedImplicitly]
    public class IntVariableTest : AbstractVariableTest<int>
    {
        protected override AbstractVariable<int> CreateVariable() => ScriptableObject.CreateInstance<IntVariable>();

        protected override int GetValue() => 5;
    }
}
