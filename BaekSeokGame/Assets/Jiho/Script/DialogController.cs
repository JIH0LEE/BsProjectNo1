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
    public DialogData dialogData;
    public int dialogIdx=0;
    bool isTalking;
   
    void Start()
    {
        dialogIdx = 0;
        
    }

    void Update()
    {
            
    }

    public void Action(GameObject npc)
    {
        ObjectData objData = npc.GetComponent<ObjectData>();
        Talk(objData);

        //Change ui status through isTalking flag.
        hidingObject.SetActive(!isTalking);
        dialogUI.SetActive(isTalking);
    }
    void Talk(ObjectData npc)
    {

        string nameText = npc.name;
        string body = dialogData.GetDialog(npc.id, dialogIdx);
        if (body == null)
        {
            isTalking = false;
            dialogIdx = 0;
            return;
        }
        else
        {
            npcName.text = npc.name;
            dialogBody.text = dialogData.GetDialog(npc.id, dialogIdx);
            isTalking = true;
            dialogIdx++;
        }
    }
}
