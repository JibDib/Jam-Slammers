using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public void OnMove(InputAction.CallbackContext context)
    {
        var vec = context.ReadValue<Vector2>();
        print($"input collected {vec}");
       // <YOUR CLASS>().SetInputVector(vec);
    }   

}
