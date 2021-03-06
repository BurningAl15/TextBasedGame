using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageColors : MonoBehaviour
{
    public static MessageColors _instance;
    
    [SerializeField] Color32 inputColor_correct;
    [SerializeField] Color32 inputColor_incorrect;
    [SerializeField] Color32 inputColor;
    [SerializeField] Color32 inputColor_inventory;

    public Color32 Correct_Color=>inputColor_correct;
    public Color32 Incorrect_Color=>inputColor_incorrect;
    public Color32 Input_Color=>inputColor;
    public Color32 Inventory_Color=>inputColor_inventory;
    
    
    void Awake()
    {
        if (_instance == null)
            _instance = this;
    }
}
