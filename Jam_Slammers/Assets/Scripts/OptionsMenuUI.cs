using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenuUI : MonoBehaviour
{
    [SerializeField] private Toggle fullscreenToggle;

    [SerializeField] private Slider volumeSlider;
    
    // Start is called before the first frame update
    private void Start()
    {
        //assert setup is correct
        if (fullscreenToggle == null || volumeSlider == null)
        {
            throw new Exception(
                "Options menu not setup correctly, please set the value of fullscreenToggle & volumeSlider");
        }

        fullscreenToggle.onValueChanged.AddListener(OnFullscreenChanged);
        
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    private void OnVolumeChanged(float value)
    {
        AudioManager.Instance.MasterVolume = value;
    }

    private void OnFullscreenChanged(bool value)
    {
        Screen.fullScreen = value;
    }
}
