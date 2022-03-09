using UnityEngine;

namespace Variables
{
    public abstract class AbstractVariable<TV> : ScriptableObject, IValueContainer<TV>
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

        public TV GetValue()
        {
            return value;
        }

        public void SetValue(TV newValue)
        {
            if (Equals(newValue, value)) 
                return;
            
            var oldValue = value;
            value = newValue;
            OnChange(oldValue, newValue);
        }
        
        protected virtual void OnChange(TV oldValue, TV newValue) {}
    }
}