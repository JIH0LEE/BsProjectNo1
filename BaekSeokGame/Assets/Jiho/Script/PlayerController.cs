using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform joyStick;
    Rigidbody2D playerRigid;
    Vector2 speed;
   

    public string currentMapName;
    
    float power;
    float x;
    float y;
    void Start()
    {
        
        playerRigid = GetComponent<Rigidbody2D>();
        power = 5.0f ;
    }

    // Update is called once per frame
    void Update()
    {

    
       
    }
    void FixedUpdate()
    {
        speed = joyStick.anchoredPosition;
        if (speed.magnitude > 1)
        {
            speed = speed.normalized;
        }


        playerRigid.velocity = speed * power;
    }
}
