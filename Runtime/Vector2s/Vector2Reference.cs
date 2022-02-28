using System;
using UnityEngine;

namespace Variables.Vector2s
{
    [Serializable]
    public class Vector2Reference : AbstractReference<Vector2, Vector2Variable>
    {
        public Vector2Reference(Vector2 defaultConstantValue = new Vector2()) : base(defaultConstantValue)
        {
        }
    }
}