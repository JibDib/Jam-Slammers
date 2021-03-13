using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    private float _masterVolume = 1;
    
    /// <summary>
    /// Normalized volume, value should be within 0-1
    /// </summary>
    public float MasterVolume
    {
         get => _masterVolume;
         set => _masterVolume = (value >= 0 && value <= 1) ? value : throw new Exception($"Master volume set out of bounds: {value} \n Set using a value between 0 and 1");
    }

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
}
