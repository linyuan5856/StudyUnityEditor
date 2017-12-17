using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScriptWizardWindowEditor : ScriptableWizard {

    public float range = 500;
    public Color color = Color.red;
    [MenuItem("9_scriptableWizard/testWindow")]
    public static void OpenWindow()
    {
        ScriptableWizard.DisplayWizard<ScriptWizardWindowEditor>("Just a Test","Creat Light","Change Light Color");
    }


    void OnWizardCreate()
    {
        GameObject go = new GameObject("New Light");
        Light lt = go.AddComponent<Light>();
        lt.range = range;
        lt.color = color;
    }

    void OnWizardUpdate()
    {
        helpString = "Please set the color of the light!";
    }

    // When the user presses the "Apply" button OnWizardOtherButton is called.
    void OnWizardOtherButton()
    {
        if (Selection.activeTransform != null)
        {
            Light lt = Selection.activeTransform.GetComponent<Light>();

            if (lt != null)
            {
                lt.color = Color.red;
            }
        }
    }
}
