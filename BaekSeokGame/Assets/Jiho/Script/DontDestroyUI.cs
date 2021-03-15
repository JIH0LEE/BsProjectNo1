using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyUI : MonoBehaviour
{
    static DontDestroyUI instance = null;
    // Start is called before the first frame update
    void Start()
    {
       
        if (instance == null)
        {
           
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != null)
        {
           
            Destroy(this.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
