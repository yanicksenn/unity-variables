using System;
using UnityEngine;
using Variables.Floats;

namespace Variables.Quaternions
{
    /// <summary>
    /// Quaternion reference allowing to switch between constant and variable.
    /// </summary>
    [Serializable]
    public class QuaternionReference : AbstractReference<Quaternion, QuaternionVariable, QuaternionEvent>
    {
        public QuaternionReference(Quaternion defaultConstantValue = new Quaternion()) : base(defaultConstantValue)
        {
        }
    }
}