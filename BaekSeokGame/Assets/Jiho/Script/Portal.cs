using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    
    public string currentMap;
    public string nextMap;


    PlayerController playerControl;
    GameObject player;
    ClickEvent clickOk;
    bool isPlayerOn = false;
    
        void Start()
    {
        playerControl = FindObjectOfType<PlayerController>();
        clickOk = FindObjectOfType<ClickEvent>();
        player = GameObject.FindGameObjectWithTag("Player");
        if (playerControl.currentMapName == currentMap)
        {
            player.transform.position = this.transform.position;
        }
    }

    
    void Update()
    {
        if (isPlayerOn&&clickOk.isClicked)
        {

            playerControl.currentMapName = nextMap;
            clickOk.isClicked = false;
            SceneManager.LoadScene(nextMap);
           
        }
        else
        {
            clickOk.isClicked = false;
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
