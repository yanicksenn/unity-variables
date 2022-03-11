using UnityEngine;
using UnityEngine.Events;

namespace Variables
{
    public abstract class AbstractVariable<TV, TE> : ScriptableObject, IValueContainer<TV>
        where TE : UnityEvent<TV>
    {
        [SerializeField] 
        private TV value;

        [SerializeField, TextArea] 
        private string description;
        public string Description
        {
            get => description;
            set => description = value;
        }

        public abstract TE OnChangeEvent { get; }

        public TV GetValue() => value;

        public void SetValue(TV newValue)
        {
            var newInterpolatedValue = Interpolate(newValue);
            if (Equals(newInterpolatedValue, value)) 
                return;

            value = newInterpolatedValue;
            InvokeChangeEvent();
        }

        [ContextMenu("Invoke change event")]
        public void InvokeChangeEvent() => OnChangeEvent.Invoke(GetValue());

        public override string ToString()
        {
            return GetValue().ToString();
        }

        protected virtual TV Interpolate(TV newValue) => newValue;

        
#if UNITY_EDITOR
        private void OnValidate() => SetValue(value);
#endif
    }
}