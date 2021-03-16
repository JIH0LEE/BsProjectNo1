using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickEvent : MonoBehaviour
{
    public bool isClicked;

   
   public void Click()
    {
       
        isClicked = true;
    }
    
    void Start()
    {
        isClicked = false;
    }

    void Update()
    {
        
    }
}
