using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Handls))]
public class HandlsEditor : Editor
{
    Handls _hand;

    /// <summary>
    /// This function is called when the object becomes enabled and active.
    /// </summary>
    void OnEnable()
    {
        _hand = (Handls)this.target;
    }

    public override void OnInspectorGUI()
    {

        DrawDefaultInspector();
    }

    void OnSceneGUI()
    {
        Handles.Label(_hand.transform.position + new Vector3(0, 1, 0), "Handles Here");
        _hand.areaRadius = Handles.RadiusHandle(Quaternion.identity, _hand.transform.position, _hand.areaRadius);

        Handles.color = Color.blue;
        if (_hand.points != null && _hand.points.Length > 0)
            Handles.DrawLines(_hand.points);

        Handles.ArrowHandleCap(1, Vector3.forward, Quaternion.identity, 1, EventType.Repaint);

        Handles.color = Handles.xAxisColor;
        Handles.CircleHandleCap(
            0,
            _hand.transform.position + new Vector3(3f, 0f, 0f),
            _hand.transform.rotation * Quaternion.LookRotation(Vector3.right),
            1,
            EventType.Repaint
            );
        Handles.color = Handles.yAxisColor;

       float size=HandleUtility.GetHandleSize(Vector3.zero);
		Handles.DrawBezier(_hand.transform.position,
                        Vector3.zero,
                        Vector3.up,
                        -Vector3.up,
                        Color.red,
                        null,
                         size);
    }
}
