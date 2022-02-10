using UnityEditor;
using UnityEngine;

namespace CraipaiGames.Variables.Editor
{
    /**
     * Copy pasted & adapted from:
     * https://github.com/roboryantron/Unite2017/blob/master/Assets/Code/Variables/Editor/FloatReferenceDrawer.cs
     */
    public abstract class AbstractReferenceDrawer : PropertyDrawer
    {
        /// <summary>
        /// Options to display in the popup to select constant or variable.
        /// </summary>
        private readonly string[] popupOptions = 
            { "Use Constant", "Use Variable" };

        /// <summary> Cached style to use to draw the popup button. </summary>
        private GUIStyle popupStyle;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            popupStyle ??= new GUIStyle(GUI.skin.GetStyle("PaneOptions"))
            {
                imagePosition = ImagePosition.ImageOnly
            };

            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);
            
            EditorGUI.BeginChangeCheck();

            // Get properties
            var useConstant = GetSwitchProperty(property);
            var constant = GetConstantProperty(property);
            var variable = GetVariableProperty(property);

            // Calculate rect for configuration button
            var buttonRect = new Rect(position);
            buttonRect.yMin += popupStyle.margin.top + 1;
            buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
            position.xMin = buttonRect.xMax;

            // Store old indent level and set it to 0, the PrefixLabel takes care of it
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            var result = EditorGUI.Popup(buttonRect, useConstant.boolValue ? 0 : 1, popupOptions, popupStyle);
            useConstant.boolValue = result == 0;

            EditorGUI.PropertyField(position, 
                useConstant.boolValue ? constant : variable, 
                GUIContent.none);

            if (EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }

        protected abstract SerializedProperty GetSwitchProperty(SerializedProperty property);
        protected abstract SerializedProperty GetConstantProperty(SerializedProperty property);
        protected abstract SerializedProperty GetVariableProperty(SerializedProperty property);
    }
}