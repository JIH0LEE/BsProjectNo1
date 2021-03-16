using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour



 {
    public GameObject hidingObject;
    public GameObject dialogUI;
    public Text npcName;
    public Text dialogBody;
    bool isTalking;
   
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Action(GameObject npc)
    {
        if (isTalking)                      //when isTalikiing is true and Action again, change status to false.
        {
            isTalking = false;
        }
        else
        {
            isTalking = true;
            npcName.text = npc.name;
            dialogBody.text = npc.name;
        }

        //Change ui status through isTalking flag.
        hidingObject.SetActive(!isTalking);
        dialogUI.SetActive(isTalking);
    }
}
