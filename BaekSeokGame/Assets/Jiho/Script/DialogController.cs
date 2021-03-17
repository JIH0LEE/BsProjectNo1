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
    public GameObject portraitSprite;
   
    public int dialogIdx=0;
    bool isTalking;
    Image portriatImage;
    void Start()
    {
        dialogIdx = 0;

        portriatImage = portraitSprite.GetComponent<Image>();
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
        
        string nameText = npc.npcName;
        string body = dialogData.GetDialog(npc.id, dialogIdx);
        if (body == null)
        {
            isTalking = false;
            dialogIdx = 0;
            return;
        }
        else
        {
            npcName.text =nameText;
            dialogBody.text = body.Split(':')[0];
            portriatImage.sprite = dialogData.GetPortrait(npc.id,int.Parse(body.Split(':')[1]));
            isTalking = true;
            dialogIdx++;
        }
    }
}
