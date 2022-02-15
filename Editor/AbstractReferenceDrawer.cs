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

            // Get properties
            var useConstant = GetUseConstantProperty(property);
            var constant = GetConstantProperty(property);
            var variable = GetVariableProperty(property);

            if (constant.propertyType != SerializedPropertyType.Generic)
                DrawInlineProperty(position, property, label, useConstant, constant, variable);
            else
                DrawGenericProperty(position, property, label, useConstant, constant, variable);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var constant = GetConstantProperty(property);
            if (IsGenericProperty(constant))
                return base.GetPropertyHeight(property, label);
            
            var useConstant = GetUseConstantProperty(property);
            var variable = GetVariableProperty(property);
            return GetGenericPropertyHeight(property, label, useConstant, constant, variable);
        }

        protected abstract SerializedProperty GetUseConstantProperty(SerializedProperty property);
        protected abstract SerializedProperty GetConstantProperty(SerializedProperty property);
        protected abstract SerializedProperty GetVariableProperty(SerializedProperty property);
        

        private void DrawInlineProperty(Rect position, SerializedProperty property, GUIContent label,
            SerializedProperty useConstant, SerializedProperty constant, SerializedProperty variable)
        {
            label = EditorGUI.BeginProperty(position, label, property);
            position = EditorGUI.PrefixLabel(position, label);

            EditorGUI.BeginChangeCheck();

            // Calculate rect for configuration button
            var buttonRect = new Rect(position);
            buttonRect.yMin += popupStyle.margin.top + 1;
            buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
            position.xMin = buttonRect.xMax;
            
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

        private void DrawGenericProperty(Rect position, SerializedProperty property, GUIContent label,
            SerializedProperty useConstant, SerializedProperty constant, SerializedProperty variable)
        {
            label = EditorGUI.BeginProperty(position, label, property);
            var firstPosition = EditorGUI.PrefixLabel(position, label);

            EditorGUI.BeginChangeCheck();
            
            // Calculate rect for configuration button
            var buttonRect = new Rect(firstPosition);
            buttonRect.y += 2;
            buttonRect.height = popupStyle.fixedHeight + popupStyle.margin.top;
            buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right;
            firstPosition.xMin = buttonRect.xMax;
            
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            var result = EditorGUI.Popup(buttonRect, useConstant.boolValue ? 0 : 1, popupOptions, popupStyle);
            useConstant.boolValue = result == 0;

            if (useConstant.boolValue) {
                EditorGUI.indentLevel = indent + 1;
                
                position.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                EditorGUI.PropertyField(position, constant, true);
            }
            else
                EditorGUI.PropertyField(firstPosition, variable, GUIContent.none);

            if (EditorGUI.EndChangeCheck())
                property.serializedObject.ApplyModifiedProperties();

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }

        private float GetGenericPropertyHeight(SerializedProperty property, GUIContent label, SerializedProperty useConstant, SerializedProperty constant, SerializedProperty variable)
        {
            var height = EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            if (!useConstant.boolValue)
                return height;

            return height + EditorGUI.GetPropertyHeight(constant, label);
        }

        private static bool IsGenericProperty(SerializedProperty constant)
        {
            return constant.propertyType != SerializedPropertyType.Generic;
        }
    }
}
