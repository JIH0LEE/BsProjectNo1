using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
   
    Rigidbody2D playerRigid;
    Vector2 movement;
    Animator anim;
    Vector3 lookingVec;
    RaycastHit2D rayHit;
    GameObject scanObj;

    public float speed = 5f;


    public GameObject OKbutton;
    public Joystick joystick;
    public DialogController dialog;
    public string currentMapName;
    
    float power;
    float x;
    float y;


    public void Talkwith()
    {

        if(scanObj == null)
        {
            return;
        }
       else if (scanObj.layer == LayerMask.NameToLayer("Npc"))
        {
            dialog.Action(scanObj);
        }

        return;
    }
    
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
                lookingVec = Vector3.right;
                return 1;
            }
            else
            {
                lookingVec = Vector3.up;
                return 4;
            }
        }
        else if (x >= 0 && y <= 0)
        {
            if (Mathf.Abs(x) >= Mathf.Abs(y))
            {
                lookingVec = Vector3.right;
                return 1;
            }
            else
            {
                lookingVec = Vector3.down;
                return 2;
            }
        }
        else if (x <= 0 && y >= 0)
        {
            if (Mathf.Abs(x) >= Mathf.Abs(y))
            {
                lookingVec = Vector3.left;
                return 3;
            }
            else
            {
                lookingVec = Vector3.up;
                return 4;
            }
        }
        else if (x <= 0 && y <= 0)
        {
            if (Mathf.Abs(x) >= Mathf.Abs(y))
            {
                lookingVec = Vector3.left;
                return 3;
            }
            else
            {
                lookingVec = Vector3.down;
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

 
    void Update()
    {
 
        if (OKbutton.GetComponent<PointerListener>().pressed&& scanObj != null)
        {
            
            Talkwith();
            OKbutton.GetComponent<PointerListener>().pressed = false;
        }

        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
    }
    
       
    
    void FixedUpdate()
    {
        


        playerRigid.velocity = movement * speed;
        x = movement.x;
        y = movement.y; 
        anim.SetInteger("playerDirection", PlayerDir(x, y));



        Debug.DrawRay(playerRigid.position,lookingVec*0.5f,new Color(0,1,0));
        rayHit = Physics2D.Raycast(playerRigid.position, lookingVec, 0.5f, LayerMask.GetMask("Npc"));
        if (rayHit.collider != null)
        {
            scanObj = rayHit.collider.gameObject;
           
        }
        else
        {
            scanObj = null;
        }
    }

    
}
