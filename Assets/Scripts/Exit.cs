using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//With System.Serializable lets you embed a class with sub properties
//In the inspector

//You can use this to display variables in the inspector similar to how a Vector3
//Shows up in the inspector.
//The name and triangle to expand its properties.
//To do this you need to create a class that derives from system.Object and give
//it the Serializable Attribute.

[System.Serializable]
public class Exit
{
    public string keyString;
    public string exitDescription;
    public Room valueRoom;
}
