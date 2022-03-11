using System;
using UnityEngine;
using UnityEngine.Events;

namespace Variables.Floats
{
    /// <summary>
    /// Serializable UnityEvent with string payload.
    /// </summary>
    [Serializable]
    public class StringEvent : UnityEvent<string>
    {
        
    }
}