using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{
    public Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
    
    [HideInInspector] public List<string> nounsInRoom = new List<string>();

    private List<string> nounsInInventory = new List<string>();
    
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

    public void ClearCollections()
    {
        examineDictionary.Clear();
        nounsInRoom.Clear();
    }
}
