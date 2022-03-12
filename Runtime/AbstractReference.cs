using System;
using UnityEngine;
using UnityEngine.Events;

namespace Variables
{
    /// <summary>
    /// Abstract reference holding a constant and a variable.
    /// </summary>
    /// <typeparam name="T">Type of value</typeparam>
    /// <typeparam name="TV">Type of variable</typeparam>
    /// <typeparam name="TE">Type of event</typeparam>
    [Serializable]
    public abstract class AbstractReference<T, TV, TE> : IValueContainer<T>
        where TV : AbstractVariable<T, TE>, IValueContainer<T>
        where TE : UnityEvent<T>
    {
        [SerializeField]
        private bool useConstant = true;
        
        /// <summary>
        /// Toggle to indicate which value should be used.
        /// </summary>
        public bool UseConstant
        {
            get => useConstant;
            set => useConstant = value;
        }
        
        [SerializeField]
        private T constant;
        
        /// <summary>
        /// Constant value.
        /// </summary>
        public T Constant
        {
            get => constant;
            set => constant = value;
        }

        [SerializeField]
        private TV variable;
        
        /// <summary>
        /// Variable value.
        /// </summary>
        public TV Variable
        {
            get => variable;
            set => variable = value;
        }

        protected AbstractReference(T defaultConstantValue)
        {
            constant = defaultConstantValue;
        }

        public T GetValue()
        {
            if (UseConstant)
                return Constant;

            if (Variable != null)
                return Variable.GetValue();
            
            return default;
        }

        public void SetValue(T value)
        {
            if (UseConstant)
                Constant = value;
            
            else if (Variable != null)
                Variable.SetValue(value);
        }
    }
}