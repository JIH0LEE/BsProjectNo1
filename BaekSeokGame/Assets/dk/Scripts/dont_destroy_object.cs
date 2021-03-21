using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dont_destroy_object : MonoBehaviour
{
    static dont_destroy_object instance = null;

    void Start()
    {

        if (instance == null)                           //Don't Destroy on next scene, if there is not same Object.
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != null)                         //Don create new Object when going to next scene.
        {

            Destroy(this.gameObject);
        }


    }
}
