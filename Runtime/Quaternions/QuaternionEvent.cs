using System;
using UnityEngine;
using UnityEngine.Events;

namespace Variables.Floats
{
    /// <summary>
    /// Serializable UnityEvent with quaternion payload.
    /// </summary>
    [Serializable]
    public class QuaternionEvent : UnityEvent<Quaternion>
    {
        
    }
}