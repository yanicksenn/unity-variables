using UnityEngine;
using UnityEngine.Events;

namespace Variables
{
    /// <summary>
    /// Abstract variable holding a value.
    /// </summary>
    /// <typeparam name="T">Type of the value</typeparam>
    /// <typeparam name="TE">Type of the event</typeparam>
    public abstract class AbstractVariable<T, TE> : ScriptableObject, IValueContainer<T>
        where TE : UnityEvent<T>
    {
        [SerializeField] 
        private T value;

        [SerializeField, TextArea] 
        private string description;
        
        /// <summary>
        /// Description.
        /// </summary>
        public string Description
        {
            get => description;
            set => description = value;
        }

        public abstract TE OnChangeEvent { get; }

        /// <summary>
        /// Returns the current value.
        /// </summary>
        /// <returns>Current value</returns>
        public T GetValue() => value;

        /// <summary>
        /// Sets the current value.
        /// </summary>
        /// <param name="newValue">New value</param>
        public void SetValue(T newValue)
        {
            var newInterpolatedValue = Interpolate(newValue);
            if (Equals(newInterpolatedValue, value)) 
                return;

            value = newInterpolatedValue;
            InvokeChangeEvent();
        }

        /// <summary>
        /// Invokes the OnChangeEvent with the current payload.
        /// </summary>
        [ContextMenu("Invoke change event")]
        public void InvokeChangeEvent() => OnChangeEvent.Invoke(GetValue());
        
        public override string ToString()
        {
            return GetValue().ToString();
        }

        /// <summary>
        /// Interpolates the new value before assigning and firing the OnChangeEvent.
        /// </summary>
        /// <param name="newValue">New value</param>
        /// <returns>New interpolated value</returns>
        protected virtual T Interpolate(T newValue) => newValue;

        
#if UNITY_EDITOR
        private void OnValidate() => SetValue(value);
#endif
    }
}