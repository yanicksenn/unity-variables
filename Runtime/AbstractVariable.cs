using UnityEngine;

namespace Variables
{
    public abstract class AbstractVariable<V> : ScriptableObject, IVariable<V>
    {
        [SerializeField] 
        private V value;
        public V Value
        {
            get => GetValue();
            set => SetValue(value);
        }

        [SerializeField, TextArea] 
        private string description;
        public string Description
        {
            get => description;
            set => description = value;
        }

        public V GetValue()
        {
            return value;
        }

        public void SetValue(V newValue)
        {
            if (Equals(newValue, value)) 
                return;
            
            var oldValue = value;
            value = newValue;
            OnChange(oldValue, newValue);
        }
        
        protected virtual void OnChange(V oldValue, V newValue) {}
    }
}