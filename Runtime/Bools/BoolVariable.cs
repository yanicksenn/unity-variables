using UnityEngine;
using Variables.unity_variables.Runtime;

namespace Variables.Bools
{
    /// <summary>
    /// Bool variable wrapped in a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(menuName = VariableConstants.RootMenu + "/Create bool variable", fileName = "BoolVariable")]
    public class BoolVariable : AbstractVariable<bool>, IBoolOperations
    {
        [SerializeField, Space]
        private BoolEvent onChangeEvent = new BoolEvent();
        public BoolEvent OnChangeEvent => onChangeEvent;
        
        public void Inv() => SetValue(!GetValue());
        public void True() => SetValue(true);
        public void False() => SetValue(false);
        

        [ContextMenu("Invoke change event")]
        public void InvokeChangeEvent()
        {
            OnChangeEvent.Invoke(GetValue());
        }
        
        protected override void OnChange(bool oldValue, bool newValue)
        {
            OnChangeEvent.Invoke(newValue);
        }
    }
}
