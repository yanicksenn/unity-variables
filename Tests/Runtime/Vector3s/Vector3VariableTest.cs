using CraipaiGames.Variables.Vector3s;
using JetBrains.Annotations;
using UnityEngine;

namespace CraipaiGames.Variables.Tests.Vector3s
{
    [UsedImplicitly]
    public class Vector3VariableTest : AbstractVariableTest<Vector3>
    {
        protected override AbstractVariable<Vector3> CreateVariable() => ScriptableObject.CreateInstance<Vector3Variable>();

        protected override Vector3 GetValue() => new Vector3(1, 2, 3);
    }
}
