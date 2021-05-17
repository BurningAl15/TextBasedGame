using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextInput : MonoBehaviour
{
    public TMP_InputField InputField;
    private GameController controller;
    
    
    private void Awake()
    {
        controller = GetComponent<GameController>();
        InputField.onEndEdit.AddListener(AcceptStringInput);
    }

    void AcceptStringInput(string userInput)
    {
        userInput = userInput.ToLower();
        controller.LogStringWithReturn(userInput);

        char[] delimiterCharacters = {' '};
        string[] separatedInputWords = userInput.Split(delimiterCharacters);

        for (int i = 0; i < controller.inputActions.Length; i++)
        {
            InputAction inputAction = controller.inputActions[i];
            if (inputAction.keyWord == separatedInputWords[0])
            {
                inputAction.RespondToInput(controller,separatedInputWords);
            }
        }
        
        InputComplete();
    }

    void InputComplete()
    {
        controller.DisplayLoggedText();
        InputField.ActivateInputField();
        InputField.text = null;
    }
}
