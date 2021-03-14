using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    private int _playerCount = 0;
    private List<PlayerModels> _selectedPlayerModels = new List<PlayerModels>();

    //INIT SINGLETON
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }


    public void SetPlayerModels(GameObject rider, GameObject player)
    {
        _selectedPlayerModels.Add(new PlayerModels(rider, player));
        _playerCount = _selectedPlayerModels.Count;
    }

    struct PlayerModels
    {
        public PlayerModels(GameObject r, GameObject p)
        {
            Rider = r;
            Player = p;
        }

        public GameObject Rider;
        public GameObject Player;
    }
    
}
