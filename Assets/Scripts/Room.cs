using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Scriptable Objects are scripts like monobehaviour but not attached
//to GameObjects

//Can be used to create assets which store data or execute code.

[CreateAssetMenu(menuName = "TextAdventure/Room")]
public class Room : ScriptableObject
{
    //Display a bigger text entry box in the inspector
    [TextArea]
    public string description;
    public string roomName;
    public Exit[] exits;
}
