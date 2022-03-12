using System;
using UnityEngine;
using Variables.Floats;

namespace Variables.Vector2s
{
    /// <summary>
    /// Vector2 reference allowing to switch between constant and variable.
    /// </summary>
    [Serializable]
    public class Vector2Reference : AbstractReference<Vector2, Vector2Variable, Vector2Event>
    {
        public Vector2Reference(Vector2 defaultConstantValue = new Vector2()) : base(defaultConstantValue)
        {
        }
    }
}