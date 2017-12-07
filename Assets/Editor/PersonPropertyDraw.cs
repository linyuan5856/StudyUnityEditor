using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Person))]
public class PersonPropertyDraw : PropertyDrawer
{

	GUIContent hp=new GUIContent();
	GUIContent Name=new GUIContent();
	GUIContent Death=new GUIContent();
	GUIContent ATKTYPE=new GUIContent();
	


    public override void OnGUI(UnityEngine.Rect position, SerializedProperty property, UnityEngine.GUIContent label)
    {
		
        var nameRect = new Rect(position.x, position.y, position.width, position.height/3);
        var hpRect = new Rect(position.x, position.y + position.height/3, position.width/2, position.height/3);
        var deathRect = new Rect(position.x+position.width/2, position.y +position.height/3, position.width/2, position.height/3);
        var typeRect = new Rect(position.x, position.y + position.height/3*2, position.width, position.height/3);

        hp.text="HP";
		Name.text="Name";
		Death.text="Death";
		ATKTYPE.text="ATKTYPE";
      
        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative("name"),Name);        
        EditorGUI.PropertyField(hpRect, property.FindPropertyRelative("hp"), hp);
        EditorGUI.PropertyField(deathRect, property.FindPropertyRelative("isDeath"),Death);
        EditorGUI.PropertyField(typeRect , property.FindPropertyRelative("AtkType"),ATKTYPE);

    }


    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label)*3;
    }

}
