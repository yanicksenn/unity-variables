using UnityEngine;

namespace Variables
{
    public abstract class AbstractVariable<T> : ScriptableObject, IVariable<T>
    {
        [SerializeField] 
        private T value;
        public T Value
        {
            get => GetValue();
            set => SetValue(value);
        }

        [SerializeField, Space, TextArea] 
        private string description;


        public string Description
        {
            get => description;
            set => description = value;
        }

        public T GetValue()
        {
            return value;
        }

        public void SetValue(T value)
        {
            this.value = value;
        }
    }
}