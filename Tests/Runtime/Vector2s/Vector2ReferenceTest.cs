using UnityEngine;
using Variables.Quaternions;
using Variables.Vector2s;

namespace Variables.Tests.Quaternions
{
    public class Vector2ReferenceTest : AbstractReferenceTest<Vector2, Vector2ValueContainer, Vector2Reference>
    {
        protected override Vector2Reference CreateReference()
        {
            return new Vector2Reference();
        }

        protected override Vector2ValueContainer CreateVariable()
        {
            return ScriptableObject.CreateInstance<Vector2ValueContainer>();
        }

        protected override Vector2 CreateRandomValue()
        {
            return Random.insideUnitCircle;
        }
    }
}