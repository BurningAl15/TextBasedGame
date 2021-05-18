using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class RoomNavigation : MonoBehaviour
{
    public Room currentRoom;

    private Dictionary<string, Room> exitDictionary = new Dictionary<string, Room>();
    private GameController controller;

    // public Color32 inputColor_correct;
    // public Color32 inputColor_incorrect;
    // public Color32 inputColor;
    
    private void Awake()
    {
        controller = GetComponent<GameController>();
    }

    public void UnpackExitsInRoom()
    {
        for (int i = 0; i < currentRoom.exits.Length; i++)
        {
            exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueRoom);
            controller.interactionDescriptionsInRoom.Add( currentRoom.exits[i].exitDescription);
        }
    }

    public void AttemptToChangeRooms(string directionNoun)
    {
        if (exitDictionary.ContainsKey(directionNoun))
        {
            currentRoom = exitDictionary[directionNoun];
            controller.LogStringWithReturn(StringUtils.ToHexadecimal("> You head off to the " + directionNoun, MessageColors._instance.Correct_Color));
            controller.DisplayRoomText();
        }
        else
        {
            controller.LogStringWithReturn(StringUtils.ToHexadecimal("> There is no path to the " + directionNoun, MessageColors._instance.Incorrect_Color));
        }
    }

    public void ClearExits()
    {
        exitDictionary.Clear();
    }
}