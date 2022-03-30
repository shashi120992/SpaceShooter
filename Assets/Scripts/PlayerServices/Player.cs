using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player instance; 
    private void Awake()
    {
        if (instance == null) 
            instance = this;
    }
}
















