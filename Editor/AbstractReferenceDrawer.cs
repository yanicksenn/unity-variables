using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Variables.Editor
{
    /// <summary>
    /// Abstract property drawer for references.
    /// </summary>
    public abstract class AbstractReferenceDrawer : PropertyDrawer
    {
        /// <summary>
        /// Use constant option.
        /// </summary>
        private static readonly string PopupOptionUseConstant = "Use Constant";

        /// <summary>
        /// Use variable option.
        /// </summary>
        private static readonly string PopupOptionUseVariable = "Use Variable";

        /// <summary>
        /// Options to display in the popup to select constant or variable.
        /// </summary>
        private static readonly string[] PopupOptions =
            { PopupOptionUseConstant, PopupOptionUseVariable };

        /// <summary> Cached style to use to draw the popup button. </summary>
        private static GUIStyle PopupStyle;

        /// <summary>
        /// The height of a single line.
        /// </summary>
        private static readonly float SingleLineHeight =
            EditorGUIUtility.singleLineHeight;

        /// <summary>
        /// The height of a single line including the vertical space.
        /// </summary>
        private static readonly float SingleLineHeightWithSpace =
            SingleLineHeight + EditorGUIUtility.standardVerticalSpacing;


        public override void OnGUI(Rect totalPosition, SerializedProperty property, GUIContent label)
        {
            var properties = FindProperties(property);
            var rootProperty = properties.RootProperty;
            var useConstantProperty = properties.UseConstantProperty;
            var constantProperty = properties.ConstantProperty;

            label = EditorGUI.BeginProperty(totalPosition, label, rootProperty);

            // Extracting the space left for the popup button.
            var firstRowPosition = EditorGUI.PrefixLabel(totalPosition, label);

            EditorGUI.BeginChangeCheck();

            // Set indent to zero for popup button since the prefix label already takes care of this.
            var indent = EditorGUI.indentLevel;
            EditorGUI.indentLevel = 0;

            var buttonPosition = CalculatePopupButtonRect(firstRowPosition);
            firstRowPosition.x += buttonPosition.width;
            firstRowPosition.width -= buttonPosition.width;

            var useConstant = DrawUseConstantPopup(buttonPosition, useConstantProperty);
            useConstantProperty.boolValue = useConstant;

            if (IsGenericProperty(constantProperty))
                DrawGenericPropertyField(firstRowPosition, properties, useConstant, indent, totalPosition);
            else
                DrawInlinePropertyField(firstRowPosition, properties, useConstant);

            if (EditorGUI.EndChangeCheck())
                rootProperty.serializedObject.ApplyModifiedProperties();

            EditorGUI.indentLevel = indent;
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            var properties = FindProperties(property);
            if (IsGenericProperty(properties.ConstantProperty))
            {
                return GetGenericPropertyHeight(properties, label);
            }

            return base.GetPropertyHeight(property, label);
        }

        /// <summary>
        /// Returns the property name of the use-constant switch. 
        /// </summary>
        /// <returns>Property name</returns>
        protected abstract string GetUseConstantPropertyName();

        /// <summary>
        /// Returns the property name of the constant property. 
        /// </summary>
        /// <returns>Property name</returns>
        protected abstract string GetConstantPropertyName();

        /// <summary>
        /// Returns the property name of the variable property. 
        /// </summary>
        /// <returns>Property name</returns>
        protected abstract string GetVariablePropertyName();

        private void DrawInlinePropertyField(Rect firstRowPosition, Properties properties, bool useConstant)
        {
            if (useConstant)
                EditorGUI.PropertyField(firstRowPosition, properties.ConstantProperty, GUIContent.none);
            else
                DrawVariableFieldWithPreview(firstRowPosition, properties);
        }

        private Rect CalculatePopupButtonRect(Rect firstRowPosition)
        {
            var additionalMarginTop = 1;
            var additionalMarginRight = 3;
            var buttonRect = new Rect(firstRowPosition);
            buttonRect.y += additionalMarginTop;
            GUIStyle popupStyle = GetPopupStyle();
            buttonRect.height = popupStyle.fixedHeight + popupStyle.margin.top;
            buttonRect.width = popupStyle.fixedWidth + popupStyle.margin.right + additionalMarginRight;
            return buttonRect;
        }

        private void DrawGenericPropertyField(Rect firstRowPosition, Properties properties, bool useConstant, int indent, Rect totalPosition)
        {
            if (useConstant)
            {
                // Increase indent by one so the constant property has indent and does not seem to be independent of the
                // label in the first row.
                EditorGUI.indentLevel = indent + 1;

                // Draw the constant property field. Include children must be true, otherwise nothing will be drawn.
                var immediateChildren = GetImmediateChildren(properties.ConstantProperty);
                foreach (var immediateChild in immediateChildren)
                {
                    // Move to new line should be the first action so all children are drawn below the label.
                    totalPosition.y += SingleLineHeightWithSpace;

                    var childRect = new Rect(totalPosition);
                    childRect.height = SingleLineHeight;
                    EditorGUI.PropertyField(childRect, immediateChild, true);
                }
            }
            else
            {
                DrawVariableFieldWithPreview(firstRowPosition, properties);
            }
        }

        private static void DrawVariableFieldWithPreview(Rect firstRowPosition, Properties properties)
        {
            var space = 3;
            var variableWidth = (firstRowPosition.width - space) * (2f / 3f);
            var variablePropertyRect = new Rect(firstRowPosition);
            variablePropertyRect.width = variableWidth;

            // Draw the variable property field. It is important that no label is drawn because we already did that
            // separately with PrefixLabel to ensure the popup button is between label and property field.
            EditorGUI.PropertyField(variablePropertyRect, properties.VariableProperty, GUIContent.none);

            var previewWidth = (firstRowPosition.width - space) * (1f / 3f);
            var previewPropertyRect = new Rect(variablePropertyRect);
            previewPropertyRect.width = previewWidth;
            previewPropertyRect.x += space + variablePropertyRect.width;

            var targetObject = properties.VariableProperty.objectReferenceValue;
            var wasEnabled = GUI.enabled;
            GUI.enabled = false;
            EditorGUI.TextField(previewPropertyRect, targetObject != null ? targetObject.ToString() : "-");
            GUI.enabled = wasEnabled;
        }

        private float GetGenericPropertyHeight(Properties properties, GUIContent label)
        {
            if (properties.UseConstantProperty.boolValue)
            {
                // Generic height can simply be determined by EditorGUI instead of summing
                // the properties myself.
                return EditorGUI.GetPropertyHeight(properties.ConstantProperty, label);
            }
            return SingleLineHeightWithSpace;
        }

        private bool IsGenericProperty(SerializedProperty constant)
        {
            return constant.propertyType == SerializedPropertyType.Generic;
        }

        private bool DrawUseConstantPopup(Rect buttonRect, SerializedProperty useConstantProperty)
        {
            GUIStyle popupStyle = GetPopupStyle();
            var selectedPopupIndex = EditorGUI.Popup(buttonRect, useConstantProperty.boolValue ? 0 : 1, PopupOptions,
                popupStyle);
            var useConstantPopupIndex = Array.IndexOf(PopupOptions, PopupOptionUseConstant);
            return selectedPopupIndex == useConstantPopupIndex;
        }

        private Properties FindProperties(SerializedProperty rootProperty)
        {
            var useConstantProperty = FindRequiredProperty(rootProperty, GetUseConstantPropertyName());
            var constantProperty = FindRequiredProperty(rootProperty, GetConstantPropertyName());
            var variableProperty = FindRequiredProperty(rootProperty, GetVariablePropertyName());

            return new Properties(rootProperty, useConstantProperty, constantProperty, variableProperty);
        }

        private SerializedProperty FindRequiredProperty(SerializedProperty rootProperty, string propertyName)
        {
            var relativeProperty = rootProperty.FindPropertyRelative(propertyName);
            _ = relativeProperty ?? throw new ArgumentException($"property '{propertyName}' on '{rootProperty.name}' does not exist");
            return relativeProperty;
        }

        private List<SerializedProperty> GetImmediateChildren(SerializedProperty rootProperty)
        {
            // Copy root property to prevent changes to the reference during enumation.
            var enumerator = rootProperty.Copy().GetEnumerator();
            var children = new List<SerializedProperty>();
            while (enumerator.MoveNext())
            {
                var child = (SerializedProperty)enumerator.Current;
                if (child != null && IsImmediateChild(rootProperty, child))
                    children.Add(child.Copy());
            }

            return children;
        }

        private static bool IsImmediateChild(SerializedProperty rootProperty, SerializedProperty child)
        {
            return rootProperty.depth + 1 == child.depth;
        }

        /// <summary>
        /// Struct to group all properties that are required to handle the useContant, constant and the variable properties.
        /// </summary>
        private struct Properties
        {
            /// <summary>
            /// Root property holding the useContant, constant and the variable properties
            /// </summary>
            public SerializedProperty RootProperty { get; }

            /// <summary>
            /// UseConstant property. Used to switch between constant and variable.
            /// </summary>
            public SerializedProperty UseConstantProperty { get; }

            /// <summary>
            /// Constant property. Holding the constant data.
            /// </summary>
            public SerializedProperty ConstantProperty { get; }

            /// <summary>
            /// Constant property. Holding the variable reference.
            /// </summary>
            public SerializedProperty VariableProperty { get; }

            public Properties(SerializedProperty rootProperty, SerializedProperty useConstantProperty, SerializedProperty constantProperty, SerializedProperty variableProperty)
            {
                RootProperty = rootProperty;
                UseConstantProperty = useConstantProperty;
                ConstantProperty = constantProperty;
                VariableProperty = variableProperty;
            }
        }

        private static GUIStyle GetPopupStyle()
        {
            return PopupStyle ??= new(GUI.skin.GetStyle("PaneOptions"))
            {
                imagePosition = ImagePosition.ImageOnly
            };
        }
    }
}
