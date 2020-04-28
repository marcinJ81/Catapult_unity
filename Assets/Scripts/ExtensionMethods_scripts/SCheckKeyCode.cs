using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SCheckKeyCode
{
    public static bool CheckKeyCode(KeyCode key)
    {
        int keyValue = (int)key;
        if ((keyValue >= 32 && keyValue <= 127) || (keyValue >= 273 && keyValue <= 276))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
