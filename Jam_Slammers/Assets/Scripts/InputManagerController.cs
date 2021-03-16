using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManagerController : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
    }
}
