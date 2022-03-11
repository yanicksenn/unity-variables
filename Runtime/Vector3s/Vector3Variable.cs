using UnityEngine;
using Variables.Floats;

namespace Variables.Vector3s
{
    [CreateAssetMenu(menuName = VariableConstants.RootMenu + "/Create Vector3 variable", fileName = "Vector3Variable")]
    public class Vector3Variable : AbstractVariable<Vector3, Vector3Event>
    {
        [SerializeField, Space]
        private Vector3Event onChangeEvent = new Vector3Event();
        public override Vector3Event OnChangeEvent => onChangeEvent;
    }
}
