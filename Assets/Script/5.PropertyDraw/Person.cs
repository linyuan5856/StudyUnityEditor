using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Attack
{
    Bad,
    Good,
    None
}

[System.Serializable]
public class Person
{
    public float hp;
    public string name;
    
	public Attack AtkType;

	public bool isDeath;

}
