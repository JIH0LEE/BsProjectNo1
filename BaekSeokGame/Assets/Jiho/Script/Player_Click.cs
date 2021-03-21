using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_Click : MonoBehaviour
{

    bool isPlayerOnPortal;

    bool isPlayerOnNPC;

    string transferMapName;

    string talkNPCName;

    public Portal portal;
    // Start is called before the first frame update
    void Start()
    {
        isPlayerOnPortal = false;
        isPlayerOnNPC = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void OnTriggerEnter2D(Collider2D Object)
    {

        Debug.Log(Object.gameObject);

        if (Object.tag == "portals")
        {

            isPlayerOnPortal = true;
            portal = Object.gameObject.GetComponent<Portal>();
        }
        if (Object.tag == "npc")
        {
            isPlayerOnNPC = true;
        }

    }
    void OnTriggerExit2D(Collider2D Object)
    {

        if (Object.tag == "portals")
        {
            isPlayerOnPortal = false;
            portal = null;
        }
        if (Object.tag == "npc")
        {
            isPlayerOnNPC = false;
        }

    }
    public void Click()
    {
        Debug.Log("click");
        if (isPlayerOnPortal == true)
        {
            Portal();
        }
        if (isPlayerOnNPC == true)
        {
            Talk();
        }
    }

    public void Portal()
    {
        Debug.Log("portal click");
        Debug.Log(portal.nextMap);
        SceneManager.LoadScene(portal.nextMap);
        this.transform.position = portal.nextPosition;
    }

    public void Talk()
    {
        Debug.Log("npc click");
    }

}
