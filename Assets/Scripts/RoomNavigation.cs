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

    [FormerlySerializedAs("inputColor")] [FormerlySerializedAs("textColor")] [SerializeField] private Color32 inputColor_correct;
    [FormerlySerializedAs("inputColor")] [FormerlySerializedAs("textColor")] [SerializeField] private Color32 inputColor_incorrect;
    
    private void Awake()
    {
        controller = GetComponent<GameController>();
    }

    public void UnpackExitsInRoom()
    {
        for (int i = 0; i < currentRoom.exits.Length; i++)
        {
            exitDictionary.Add(currentRoom.exits[i].keyString, currentRoom.exits[i].valueRoom);
            controller.interactionDescriptionsInRoom.Add("\n" + currentRoom.exits[i].exitDescription);
        }
    }

    public void AttemptToChangeRooms(string directionNoun)
    {
        if (exitDictionary.ContainsKey(directionNoun))
        {
            currentRoom = exitDictionary[directionNoun];
            controller.LogStringWithReturn(StringUtils.ToHexadecimal("> You head off to the " + directionNoun, inputColor_correct));
            controller.DisplayRoomText();
        }
        else
        {
            controller.LogStringWithReturn(StringUtils.ToHexadecimal("> There is no path to the " + directionNoun, inputColor_incorrect));
        }
    }

    public void ClearExits()
    {
        exitDictionary.Clear();
    }
}