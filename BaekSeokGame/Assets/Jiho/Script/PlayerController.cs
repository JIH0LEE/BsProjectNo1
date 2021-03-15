using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform joyStick;
    Rigidbody2D playerRigid;
    Vector2 speed;
    Animator anim;
   

    public string currentMapName;
    
    float power;
    float x;
    float y;

    public int PlayerDir(float x,float y)
    {
        if (x == 0 && y == 0)
        {
            return 0;
        }
        else if (x >= 0 && y >= 0)
        {
            if (Mathf.Abs(x) >= Mathf.Abs(y))
            {
                return 1;
            }
            else
            {
                return 4;
            }
        }
        else if (x >= 0 && y <= 0)
        {
            if (Mathf.Abs(x) >= Mathf.Abs(y))
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
        else if (x <= 0 && y >= 0)
        {
            if (Mathf.Abs(x) >= Mathf.Abs(y))
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }
        else if (x <= 0 && y <= 0)
        {
            if (Mathf.Abs(x) >= Mathf.Abs(y))
            {
                return 3;
            }
            else
            {
                return 2;
            }
        }
        return 0;
       
    }
    void Start()
    {
        anim = GetComponent<Animator>();
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
        x = playerRigid.velocity.x;
       y= playerRigid.velocity.y;
        anim.SetInteger("playerDirection", PlayerDir(x, y));
    }
}
