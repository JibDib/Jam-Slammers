using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CosmeticLoader : MonoBehaviour
{
    [SerializeField] private string filePathToCosmetics = "";
    [SerializeField] private string ridableFolderName = "";
    [SerializeField] private string playerFolderName = "";

    [SerializeField] private GameObject ridableMenuParent;
    [SerializeField] private Button ridableButtonTemplate;
    [SerializeField] private GameObject playerMenuParent;
    [SerializeField] private Button playerButtonTemplate;

    
    private List<GameObject> ridableObjects = new List<GameObject>();
    private List<GameObject> playerObjects = new List<GameObject>();
    
    private List<Image> rideableSprites = new List<Image>();
    private List<Image> playerSprites = new List<Image>();
    

    private void Start()
    {
        //load all resources
        ridableObjects = Resources.LoadAll<GameObject>(filePathToCosmetics + "/" + ridableFolderName).ToList();
        playerObjects = Resources.LoadAll<GameObject>(filePathToCosmetics + "/" + playerFolderName).ToList();

        //obtain sprites
        rideableSprites = ridableObjects.Select(ridable => ridable.GetComponent<Image>()).ToList();
        playerSprites = playerObjects.Select(player => player.GetComponent<Image>()).ToList();
        
        //Build UI menu - Add sprites to buttons - Add event to select correct cosmetics
        for (var i = 0; i < ridableObjects.Count; i++)
        {
            if (i != 0)
            {
                var btn = Instantiate(ridableButtonTemplate, ridableMenuParent.GetComponent<GridLayoutGroup>().transform);
                //btn.onClick.AddListener(); set player rider model
                //btn.image.sprite = rideableSprites[i];
            }
            else
            {
                ridableButtonTemplate.image.sprite = rideableSprites[i].sprite;
                //btn.onClick.AddListener(); set player rider model
            }
        }

        for (var i = 0; i < playerObjects.Count; i++)
        {
            if (i != 0)
            {
                var btn = Instantiate(playerButtonTemplate, playerMenuParent.GetComponent<GridLayoutGroup>().transform);
                //btn.onClick.AddListener(); set player rider model
                //btn.image.sprite = playerSprites[i].sprite;  

            }
            else
            {
                playerButtonTemplate.image.sprite = playerSprites[i].sprite;
                //btn.onClick.AddListener(); set player rider model
            }
        }
    }

    public void CleanLoader()
    {
        //clean GO's
        ridableObjects.Clear();
        playerObjects.Clear();
        
        //clean sprites
        rideableSprites.Clear();
        playerSprites.Clear();
    }
}
