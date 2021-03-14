using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } // INITIALIZE SINGLETON
        else if (Instance != this)
        {
            Destroy(this);
        }
    }

    [SerializeField] private List<GameObject> dontDestroyOnLoadList = new List<GameObject>();
    private void Start()
    {
        foreach (var gos in dontDestroyOnLoadList)
        {
            DontDestroyOnLoad(gos);
        }
        DontDestroyOnLoad(this);
        
        dontDestroyOnLoadList.Clear(); // clean list
    }
}
