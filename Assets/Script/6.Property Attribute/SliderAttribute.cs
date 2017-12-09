using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderAttribute : PropertyAttribute
{


    public float mStart;
    public float mEnd;

    public SliderAttribute(float start, float end)
    {
        this.mStart = start;
        this.mEnd = end;
    }



}
