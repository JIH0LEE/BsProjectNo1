using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DontDestroy : MonoBehaviour
{
    static DontDestroy instance =null;
    // Start is called before the first frame update
    void Start()
    {
        
        if (instance == null)
        {
            
            
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if(instance!=null)
        {
            
            Destroy(this.gameObject);
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
