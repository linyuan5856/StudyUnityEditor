using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testSliderAttribute : MonoBehaviour
{

    [Slider(6f, 15f),SerializeField]
    float testFloat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
