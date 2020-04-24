using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class KeyDetecion
{
    /// <summary>
    /// https://stackoverflow.com/questions/12076107/how-to-detect-if-any-key-is-pressed
    /// </summary>
    /// <returns></returns>
    public static IEnumerable<KeyCode> KeysDown()
    {
        foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(key))
                yield return key;
        }
    }
}
