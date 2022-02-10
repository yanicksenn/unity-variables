using CraipaiGames.Variables.Floats;
using JetBrains.Annotations;
using UnityEngine;

namespace CraipaiGames.Variables.Tests.Floats
{
    [UsedImplicitly]
    public class FloatVariableTest : AbstractVariableTest<float>
    {
        protected override AbstractVariable<float> CreateVariable() => ScriptableObject.CreateInstance<FloatVariable>();

        protected override float GetValue() => 5;
    }
}
