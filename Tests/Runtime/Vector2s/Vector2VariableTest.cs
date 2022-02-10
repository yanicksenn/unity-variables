using CraipaiGames.Variables.Vector2s;
using JetBrains.Annotations;
using UnityEngine;

namespace CraipaiGames.Variables.Tests.Vector2s
{
    [UsedImplicitly]
    public class Vector2VariableTest : AbstractVariableTest<Vector2>
    {
        protected override AbstractVariable<Vector2> CreateVariable() => ScriptableObject.CreateInstance<Vector2Variable>();

        protected override Vector2 GetValue() => new Vector2(1, 2);
    }
}
