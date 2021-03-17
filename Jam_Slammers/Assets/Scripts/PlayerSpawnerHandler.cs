using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerSpawnerHandler : MonoBehaviour
    {
        [SerializeField] private List<Transform> spawnPositions = new List<Transform>();
        private void Start()
        {
            for (int i = 0; i < PlayerConfigurationManager.Instance.playerConfigs.Count; i++)
            {
                if (i <= spawnPositions.Count)
                {
                    PlayerConfigurationManager.Instance.playerConfigs[i].Input.transform.position = spawnPositions[i].position;
                }
                else
                {
                    throw new Exception($"Attempted to spawn more players than spawn points, find suitable fix :) ");
                }
            }
        }
    }
}