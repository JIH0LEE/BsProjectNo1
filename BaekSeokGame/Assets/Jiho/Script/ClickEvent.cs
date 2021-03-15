using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvent : MonoBehaviour
{
    public bool isClicked;
    // Start is called before the first frame update
   
   public void Click()
    {
       
        isClicked = true;
    }
    
    void Start()
    {
        isClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
