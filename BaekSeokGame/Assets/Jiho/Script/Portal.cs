using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    
    public string currentMap;
    public string nextMap;
    
    bool isClicked;

    PlayerController playerControl;
    GameObject player;
    GameObject okButton;
    PointerListener clickOk;
    bool isPlayerOn = false;
    
        void Start()
    {
        isClicked = false;
        okButton = GameObject.Find("OKButton");
        playerControl = FindObjectOfType<PlayerController>();
        clickOk = okButton.GetComponent<PointerListener>();   
            player = GameObject.FindGameObjectWithTag("Player");
        if (playerControl.currentMapName == currentMap)
        {
            player.transform.position = this.transform.position;
        }
    }
    public void isClickedChange()
    {
        if (isPlayerOn)
        {

            isClicked = true;
        }
    }

    
    void Update()
    {
        if (isClicked && isPlayerOn)
        {

            playerControl.currentMapName = nextMap;
            isClicked = false;
            SceneManager.LoadScene(nextMap);
        }
                   
        
    }

    void OnTriggerEnter2D(Collider2D Object)
    {
        if (Object.tag == "Player")
        {
            
            isPlayerOn = true;
           
        }

    }
    void OnTriggerExit2D(Collider2D Object)
    {
        if (Object.tag == "Player")
        {
           
            isPlayerOn = false;
           
        }

      

    }
}
