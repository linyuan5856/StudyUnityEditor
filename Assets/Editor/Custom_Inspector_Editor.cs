using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(custom_inspector))]
public class Custom_Inspector_Editor : Editor
{
    private custom_inspector inspector;


    void OnEnable()
    {
        this.inspector = (custom_inspector) target;
        inspector.name = "EnjoyCoding";
    }


    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical();
        
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Charactor InFo",GUILayout.MaxWidth(150));
        inspector.name = EditorGUILayout.TextField("player Name", inspector.name);
        EditorGUILayout.Space();

        inspector.des = EditorGUILayout.TextArea("Actor Story",GUILayout.MinHeight(100));
        EditorGUILayout.Space();

        int[] data = new[] {10, 20, 30};
        string[]show=new [] {"Min-10","Mid-20","Mix-30"};
        inspector.age = EditorGUILayout.IntPopup("Age",inspector.age,show,data);
        EditorGUILayout.Space();

        inspector.atk = EditorGUILayout.Slider("Attack",inspector.atk, 0f, 10f);
        EditorGUILayout.Space();

        inspector.def = EditorGUILayout.FloatField("Defense", inspector.def);
        EditorGUILayout.Space();

        int max = 100;
        inspector.hp = EditorGUILayout.IntSlider("Health", inspector.hp, 0,max); 
        EditorGUILayout.Space();
     
               
        Rect rect= EditorGUILayout.GetControlRect(false, 20);  
        GUI.color = Color.green;
        if (inspector.hp<80&&inspector.hp>50)
        {
            GUI.color = Color.yellow;
        }
        else if (inspector.hp<50)
        {
            GUI.color=Color.red;                  
        }
       
        EditorGUI.ProgressBar(rect,(float)inspector.hp/max,"hp" );
        EditorGUILayout.Space();
        GUI.color = Color.black;
        if (inspector.hp<20)
        {
            EditorGUILayout.Space();
            EditorGUILayout.HelpBox("Hp is Low", MessageType.Warning);
        }

        EditorGUILayout.EndVertical();
        
    }
}
