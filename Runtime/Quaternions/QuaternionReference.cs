using System;
using UnityEngine;
using Variables.Floats;

namespace Variables.Quaternions
{
    [Serializable]
    public class QuaternionReference : AbstractReference<Quaternion, QuaternionVariable, QuaternionEvent>
    {
        public QuaternionReference(Quaternion defaultConstantValue = new Quaternion()) : base(defaultConstantValue)
        {
        }
    }
}