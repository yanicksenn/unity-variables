using UnityEngine;

namespace Variables.Bools
{
    /// <summary>
    /// Bool variable wrapped in a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(
        menuName = VariableConstants.RootMenu + "/Create bool variable", 
        fileName = "BoolVariable")]
    public class BoolVariable : AbstractVariable<bool, BoolEvent>, IInvertible
    {
        [SerializeField, Space]
        private BoolEvent onChangeEvent = new BoolEvent();
        public override BoolEvent OnChangeEvent => onChangeEvent;
        
        public void Inv() => SetValue(!GetValue());
    }
}
