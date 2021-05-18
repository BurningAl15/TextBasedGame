using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableItems : MonoBehaviour
{
    public List<InteractableObject> usableItemList;
    
    public Dictionary<string, string> examineDictionary = new Dictionary<string, string>();
    public Dictionary<string, string> takeDictionary = new Dictionary<string, string>();
    
    [HideInInspector] public List<string> nounsInRoom = new List<string>();

    private Dictionary<string, ActionResponse> useDictionary = new Dictionary<string, ActionResponse>();
    
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

    public void AddActionResponsesToUseDictionary()
    {
        for (int i = 0; i < nounsInInventory.Count; i++)
        {
            string noun = nounsInInventory[i];

            InteractableObject interactableObjectInInventory = GetInteractableObjectFromUsableList(noun);

            if (interactableObjectInInventory == null)
                continue;

            for (int j = 0; j < interactableObjectInInventory.interactions.Length; j++)
            {
                Interaction interaction = interactableObjectInInventory.interactions[j];
                
                if(interaction.actionResponse==null)
                    continue;

                if (!useDictionary.ContainsKey(noun))
                {
                    useDictionary.Add(noun,interaction.actionResponse);
                }
            }
        }
    }

    InteractableObject GetInteractableObjectFromUsableList(string noun)
    {
        for (int i = 0; i < usableItemList.Count; i++)
        {
            if (usableItemList[i].noun == noun)
            {
                return usableItemList[i];
            }
        }
        return null;
    }

    public void DisplayInventory()
    {
        controller.LogStringWithReturn(StringUtils.ToHexadecimal("> You look in your backpack, inside you have: ",MessageColors._instance.Correct_Color));

        if (nounsInInventory.Count > 0)
        {
            for (int i = 0; i < nounsInInventory.Count; i++)
            {
                controller.LogStringWithReturn(StringUtils.ToHexadecimal(i +") "+nounsInInventory[i],MessageColors._instance.Inventory_Color));
            }
        }else if (nounsInInventory.Count <= 0)
        {
            controller.LogStringWithReturn(StringUtils.ToHexadecimal("Hmmm.... Nothing in the backpack",MessageColors._instance.Inventory_Color));
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
            AddActionResponsesToUseDictionary();
            nounsInRoom.Remove(noun);
            return takeDictionary;
        }
        else
        {
            controller.LogStringWithReturn(StringUtils.ToHexadecimal("> There is no " + noun + " here to take", MessageColors._instance.Incorrect_Color));
            return null;
        }
    }

    public void UseItem(string[] separatedInputWords)
    {
        string nounToUse = separatedInputWords[1];

        if (nounsInInventory.Contains(nounToUse))
        {
            if (useDictionary.ContainsKey(nounToUse))
            {
                bool actionResult = useDictionary[nounToUse].DoActionResponse(controller);
                if (!actionResult)
                {
                    controller.LogStringWithReturn(StringUtils.ToHexadecimal("Hmmm... Nothing happens",MessageColors._instance.Input_Color));
                }
            }
            else
            {
                controller.LogStringWithReturn(StringUtils.ToHexadecimal("You can't use the " + nounToUse,MessageColors._instance.Input_Color));
            }
        }
        else
        {
            controller.LogStringWithReturn(StringUtils.ToHexadecimal("There is no " + nounToUse + " in your inventory to use",MessageColors._instance.Input_Color));
        }
    }
}
