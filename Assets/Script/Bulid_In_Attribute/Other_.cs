using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Other_ : MonoBehaviour
{   //* 所有特性必须大写开头 *//
    [Header("Customer Name")]  //加粗标题
    [Multiline(5)]             //多行内容
    public string name;
    [Range(0, 1)]               //范围
    public float range;
    [Space(100)]                //和上个属性间距100px
    [Tooltip("监视板")]
    public string inspect;     //鼠标放置在这个属性上

}
