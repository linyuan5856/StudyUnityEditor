using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SliderAttribute))]
public class SliderAttributeProperyDraw :PropertyDrawer
{
    private SliderAttribute mAttribute;


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        mAttribute = (SliderAttribute)this.attribute;
        property.floatValue=EditorGUI.Slider(position,label.text,property.floatValue, mAttribute.mStart,mAttribute.mEnd);
    }
}
