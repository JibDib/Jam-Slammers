using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.Serialization;

public class SpawnPlayerSetupMenu : MonoBehaviour
{
    public GameObject playerSetupMenuPrefab;
    public PlayerInput _playerInput;
    private void Start()
    {
        var rootMenu = GameObject.FindWithTag("RootMenu");
        if (rootMenu != null)
        {
            _playerInput = GetComponent<PlayerInput>();
            var menu = Instantiate(playerSetupMenuPrefab, rootMenu.transform);
            _playerInput.uiInputModule = menu.GetComponentInChildren<InputSystemUIInputModule>();
            print($"Player index in SpawnPlayerSetupMenu is: {_playerInput.playerIndex}");
            menu.GetComponent<PlayerSetupMenuController>().SetPlayerIndex(_playerInput.playerIndex);
        }
    }
}
