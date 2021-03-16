using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour
{
    private List<PlayerConfiguration> playerConfigs;

    [SerializeField] private int MaxPlayers = 2;

    public static PlayerConfigurationManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfigs = new List<PlayerConfiguration>();
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    public void SetPlayerColor(int index, Material color)
    {
        playerConfigs[index].playerMaterial = color;
    }

    
    public void ReadyPlayer(int index)
    {
        playerConfigs[index].isReady = true;
        if (playerConfigs.Count == MaxPlayers && playerConfigs.All(p => p.isReady == true))
        {
            SceneManager.LoadScene(0); // define which scene to load elsewhere
        }
    }

    public void HandlePlayerJoin(PlayerInput pi)
    {
        Debug.Log($"Player joined: {pi.playerIndex}");
        pi.transform.SetParent(transform);
        if (!playerConfigs.Any(p => p.PlayerIndex == pi.playerIndex))
        {
            playerConfigs.Add(new PlayerConfiguration(pi));
        }
    }
    
}

public class PlayerConfiguration
{
    public PlayerConfiguration(PlayerInput pi)
    {
        PlayerIndex = pi.playerIndex;
        Input = pi;
    }

    private PlayerInput Input { get; set; }
    public int PlayerIndex { get; set; }
    public bool isReady { get; set; }
    
    public Material playerMaterial { get; set; }
}
