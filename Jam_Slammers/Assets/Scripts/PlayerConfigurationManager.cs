using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour
{
    public List<PlayerConfiguration> playerConfigs = new List<PlayerConfiguration>();

    [SerializeField] private int MaxPlayers = 2;

    public static PlayerConfigurationManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    public void SetPlayerColor(int index, Material color)
    {
        print($"playerConfigs count = {playerConfigs.Count}");
        playerConfigs[index].playerMaterial = color;
    }

    
    public void ReadyPlayer(int index)
    {
        playerConfigs[index].isReady = true;
        if (playerConfigs.Count == MaxPlayers && playerConfigs.All(p => p.isReady == true))
        {
            Destroy(Camera.main);
            SceneManager.LoadScene(2); // define which scene to load elsewhere
        }
    }

    public void HandlePlayerJoin(PlayerInput pi)
    {
        Debug.Log($"Player joined: {pi.playerIndex}");
        //pi.transform.SetParent(transform);
        if (!playerConfigs.Any(p => p.PlayerIndex == pi.playerIndex))
        {
            Instance.playerConfigs.Add(new PlayerConfiguration(pi));
            print($"player config count after adding: {playerConfigs.Count}");
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

    public PlayerInput Input { get; private set; }
    public int PlayerIndex { get; set; }
    public bool isReady { get; set; }
    
    public Material playerMaterial { get; set; }
}
