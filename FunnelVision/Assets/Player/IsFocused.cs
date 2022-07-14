using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsFocused : MonoBehaviour
{
    private bool isFocused = false;

    public bool currentlyFocused()
    {
        return isFocused;
    }
    public void setFocused(bool f)
    {
        isFocused = f;
    }
}
