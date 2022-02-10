using System;
using UnityEngine;

namespace CraipaiGames.Variables
{
    [Serializable]
    public abstract class AbstractReference<TConstant, TVariable> where TVariable : AbstractVariable<TConstant>, IVariable<TConstant>
    {
        [SerializeField]
        private bool useConstant = true;
        public bool UseConstant
        {
            get => useConstant;
            set => useConstant = value;
        }
        
        [SerializeField]
        private TConstant constant;
        public TConstant Constant
        {
            get => constant;
            set => constant = value;
        }

        [SerializeField]
        private TVariable variable;
        public TVariable Variable
        {
            get => variable;
            set => variable = value;
        }

        public TConstant Value
        {
            get => GetValue();
            set => SetValue(value);
        }

        protected AbstractReference(TConstant defaultConstantValue)
        {
            constant = defaultConstantValue;
        }

        public TConstant GetValue()
        {
            if (UseConstant)
                return Constant;

            if (Variable != null)
                return Variable.Value;
            
            return default;
        }

        public void SetValue(TConstant value)
        {
            if (UseConstant)
                Constant = value;
            
            else if (Variable != null)
                Variable.Value = value;
        }
    }
}