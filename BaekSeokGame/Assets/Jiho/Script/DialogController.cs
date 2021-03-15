using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour



 {
    public GameObject Button;
    public GameObject ui;
    public Text name;
    public Text dialogBody;
    bool isTalking;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Action(GameObject npc)
    {
        if (isTalking)
        {
            isTalking = false;
        }
        else
        {
            isTalking = true;
            
            name.text = npc.name;
            dialogBody.text = npc.name;
        }
        Button.SetActive(!isTalking);
        ui.SetActive(isTalking);
    }
}
