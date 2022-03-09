using System;
using UnityEngine.Events;

namespace Variables.Bools
{
    /// <summary>
    /// Serializable UnityEvent with bool payload.
    /// </summary>
    [Serializable]
    public class BoolEvent : UnityEvent<bool>
    {
        
    }
}