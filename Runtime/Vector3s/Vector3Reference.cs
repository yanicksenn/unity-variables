using System;
using UnityEngine;

namespace Variables.Vector3s
{
    [Serializable]
    public class Vector3Reference : AbstractReference<Vector3, Vector3Variable>
    {
        public Vector3Reference(Vector3 defaultConstantValue = new Vector3()) : base(defaultConstantValue)
        {
        }
    }
}