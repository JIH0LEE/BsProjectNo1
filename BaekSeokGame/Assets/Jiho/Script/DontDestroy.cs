using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DontDestroy : MonoBehaviour
{
    static DontDestroy instance =null;
  
    void Start()
    {
        
        if (instance == null)                           //Don't Destroy on next scene, if there is not same Object.
        { 
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if(instance!=null)                         //Don create new Object when going to next scene.
        {
            
            Destroy(this.gameObject);
        }
       
    }

  
    void Update()
    {
        
    }
}
