using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))] //必须依赖的组件
public class RequireComponent_ : MonoBehaviour
{
    [ContextMenu("log")] //组件右键点击
    void log()
    {
        Debug.LogWarning("ContextMenu");
    }

}
