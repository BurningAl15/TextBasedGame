using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{
    public Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
    public Dictionary<string, string> takeDictionary = new Dictionary<string, string>();
    
    [HideInInspector] public List<string> nounsInRoom = new List<string>();

    private List<string> nounsInInventory = new List<string>();
    private GameController controller;

    private void Awake()
    {
        controller = GetComponent<GameController>();
    }

    public string GetObjectsNotInInventory(Room currentRoom,int i)
    {
        InteractableObject interactableInRoom = currentRoom.InteractableObjectsInRoom[i];

        if (!nounsInInventory.Contains(interactableInRoom.noun))
        {
            nounsInRoom.Add(interactableInRoom.noun);
            return interactableInRoom.description;
        }

        return null;
    }

    public void DisplayInventory()
    {
        controller.LogStringWithReturn(StringUtils.ToHexadecimal("> You look in your backpack, inside you have: ",MessageColors._instance.Correct_Color));

        for (int i = 0; i < nounsInInventory.Count; i++)
        {
            controller.LogStringWithReturn(StringUtils.ToHexadecimal(i +") "+nounsInInventory[i],MessageColors._instance.Inventory_Color));
        }
    }

    public void ClearCollections()
    {
        examineDictionary.Clear();
        takeDictionary.Clear();
        nounsInRoom.Clear();
    }

    public Dictionary<string, string> Take(string[] separatedInputWords)
    {
        string noun = separatedInputWords[1];
        if (nounsInRoom.Contains(noun))
        {
            nounsInInventory.Add(noun);
            nounsInRoom.Remove(noun);
            return takeDictionary;
        }
        else
        {
            controller.LogStringWithReturn(StringUtils.ToHexadecimal("> There is no " + noun + " here to take", MessageColors._instance.Incorrect_Color));
            return null;
        }
    }
}
