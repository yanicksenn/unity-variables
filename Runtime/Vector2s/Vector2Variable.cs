using UnityEngine;
using Variables.Floats;

namespace Variables.Vector2s
{
    [CreateAssetMenu(menuName = VariableConstants.RootMenu + "/Create Vector2 variable", fileName = "Vector2Variable")]
    public class Vector2Variable : AbstractVariable<Vector2, Vector2Event>
    {
        [SerializeField, Space]
        private Vector2Event onChangeEvent = new Vector2Event();
        public override Vector2Event OnChangeEvent => onChangeEvent;
    }
}
