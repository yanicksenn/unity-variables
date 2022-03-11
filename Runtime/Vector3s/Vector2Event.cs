using System;
using UnityEngine;
using UnityEngine.Events;

namespace Variables.Floats
{
    /// <summary>
    /// Serializable UnityEvent with Vector3 payload.
    /// </summary>
    [Serializable]
    public class Vector3Event : UnityEvent<Vector3>
    {
        
    }
}