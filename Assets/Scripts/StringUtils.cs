using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StringUtils : MonoBehaviour
{
   public static string ToHexadecimal(string _content, Color32 _color)
   {
      return string.Format("<#{0}>"+_content+"</color>",ColorUtility.ToHtmlStringRGB( _color ));
   }
}
