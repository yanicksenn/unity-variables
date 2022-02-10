using System;
using UnityEngine;

namespace CraipaiGames.Variables.Quaternions
{
    [Serializable]
    public class QuaternionReference : AbstractReference<Quaternion, QuaternionVariable>
    {
        public QuaternionReference(Quaternion defaultConstantValue = new Quaternion()) : base(defaultConstantValue)
        {
        }
    }
}