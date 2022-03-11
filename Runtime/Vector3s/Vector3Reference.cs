using System;
using UnityEngine;
using Variables.Floats;

namespace Variables.Vector3s
{
    [Serializable]
    public class Vector3Reference : AbstractReference<Vector3, Vector3Variable, Vector3Event>
    {
        public Vector3Reference(Vector3 defaultConstantValue = new Vector3()) : base(defaultConstantValue)
        {
        }
    }
}