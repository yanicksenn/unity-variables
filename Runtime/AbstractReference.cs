using System;
using UnityEngine;
using UnityEngine.Events;

namespace Variables
{
    [Serializable]
    public abstract class AbstractReference<TC, TV, TE> : IValueContainer<TC>
        where TV : AbstractVariable<TC, TE>, IValueContainer<TC>
        where TE : UnityEvent<TC>
    {
        [SerializeField]
        private bool useConstant = true;
        public bool UseConstant
        {
            get => useConstant;
            set => useConstant = value;
        }
        
        [SerializeField]
        private TC constant;
        public TC Constant
        {
            get => constant;
            set => constant = value;
        }

        [SerializeField]
        private TV variable;
        public TV Variable
        {
            get => variable;
            set => variable = value;
        }

        protected AbstractReference(TC defaultConstantValue)
        {
            constant = defaultConstantValue;
        }

        public TC GetValue()
        {
            if (UseConstant)
                return Constant;

            if (Variable != null)
                return Variable.GetValue();
            
            return default;
        }

        public void SetValue(TC value)
        {
            if (UseConstant)
                Constant = value;
            
            else if (Variable != null)
                Variable.SetValue(value);
        }
    }
}