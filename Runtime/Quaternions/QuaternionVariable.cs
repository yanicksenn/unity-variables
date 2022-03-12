using UnityEngine;
using Variables.Floats;

namespace Variables.Quaternions
{
    /// <summary>
    /// Quaternion variable wrapped in a ScriptableObject.
    /// </summary>
    [CreateAssetMenu(
        menuName = VariableConstants.RootMenu + "/Create quaternion variable", 
        fileName = "QuaternionVariable")]
    public class QuaternionVariable : AbstractVariable<Quaternion, QuaternionEvent>
    {
        [SerializeField, Space]
        private QuaternionEvent onChangeEvent = new QuaternionEvent();
        public override QuaternionEvent OnChangeEvent => onChangeEvent;
    }
}
