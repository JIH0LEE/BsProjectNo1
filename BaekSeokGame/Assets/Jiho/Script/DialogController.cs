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
    public GameObject npcPortrait;
    public GameObject playerPortrait;

    public int dialogIdx=0;
    bool isTalking;
    Image npcPortraitImage;
    Image playerPortraitImage;
    void Start()
    {
        dialogIdx = 0;
        npcPortraitImage = npcPortrait.GetComponent<Image>();
        playerPortraitImage = playerPortrait.GetComponent<Image>();
    }       

    void Update()
    {
        
    }
        
    public void Action(GameObject npc)
    {
        ObjectData objData = npc.GetComponent<ObjectData>();
        
        if (npc.GetComponent<npcStatus>().oneWayTalk[0])
        {
            Talk(objData,1);
        }
        else if (!npc.GetComponent<npcStatus>().oneWayTalk[0])
        {
            Talk(objData, 2);
        }

        //Change ui status through isTalking flag.
        hidingObject.SetActive(!isTalking);
        dialogUI.SetActive(isTalking);
    }
    void Talk(ObjectData npc,int caseNum)
    {

        if (caseNum== 1){
            playerPortrait.gameObject.SetActive(false);
            string nameText = npc.npcName;
            string body = dialogData.GetNpcDialog(npc.id, dialogIdx);
            if (body == null)
            {
                isTalking = false;
                playerPortrait.gameObject.SetActive(true);
                npcPortraitImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                playerPortraitImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                dialogIdx = 0;
                return;
            }
            else
            {
                npcName.text = nameText;
                dialogBody.text = body;

                npcPortraitImage.sprite = dialogData.GetNpcPortrait(npc.id, dialogIdx);
                isTalking = true;
                dialogIdx++;
            }
        }
        else if (caseNum == 2)
        {
            if (dialogIdx % 2 == 0)
            {
                string nameText = npc.npcName;
                string body = dialogData.GetNpcDialog(npc.id, dialogIdx/2);
                
                if (body == null)
                {
                    npcPortraitImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    playerPortraitImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    isTalking = false;
                  
                    dialogIdx = 0;
                    return;
                }

                else
                {
                    npcName.text = nameText;
                    dialogBody.text = body;
                    playerPortraitImage.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                    npcPortraitImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    npcPortraitImage.sprite = dialogData.GetNpcPortrait(npc.id, dialogIdx/2);
                    isTalking = true;
                    dialogIdx++;
                }
            }
            else
            {
                string nameText = "킹갓엠퍼러제너럴유덕규";
                string body = dialogData.GetPlayerDialog(npc.id, dialogIdx/2);

                if (body == null)
                {
                    isTalking = false;
                    dialogIdx = 0;
                    return;
                }

                else
                {
                    npcName.text = nameText;    
                    dialogBody.text = body;
                    npcPortraitImage.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                    playerPortraitImage.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    playerPortraitImage.sprite = dialogData.GetPlayerPortrait(npc.id, dialogIdx/2);
                    isTalking = true;
                    dialogIdx++;
                }
            }
        }
    }
}
