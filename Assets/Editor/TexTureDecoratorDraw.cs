using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(Data))]
public class TexTureDecoratorDraw : DecoratorDrawer
{
    
    public override void OnGUI(Rect position)
    {
        Texture t = Resources.Load<Texture>("Node3");
        EditorGUI.DrawTextureTransparent(position, t, ScaleMode.ScaleToFit);
        
    }
}
