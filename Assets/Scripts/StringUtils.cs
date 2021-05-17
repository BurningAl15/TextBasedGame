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
   
   public static string[] ToHexadecimal(string[] _content, Color32 _color)
   {
      string[] temp=new string[_content.Length];
      for (int i = 0; i < _content.Length; i++)
      {
         temp[i]=string.Format("<#{0}>"+_content[i]+"</color>",ColorUtility.ToHtmlStringRGB( _color ));
      }

      return temp;
   }
}
