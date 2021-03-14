using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    private PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        var vec = context.ReadValue<Vector2>();
        print($"input collected {vec}");
        if (playerController != null)
        {
            playerController.SetInputVector(vec);
        }
    }
}
