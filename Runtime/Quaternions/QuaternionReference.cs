using System;
using UnityEngine;

namespace Variables.Quaternions
{
    [Serializable]
    public class QuaternionReference : AbstractReference<Quaternion, QuaternionVariable>
    {
        public QuaternionReference(Quaternion defaultConstantValue = new Quaternion()) : base(defaultConstantValue)
        {
        }
    }
}