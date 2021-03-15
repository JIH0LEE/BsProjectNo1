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
    Vector3 lookingVec;
    RaycastHit2D rayHit;
    GameObject scanObj;
   public GameObject OKbutton;
    
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
    public void Test()
    {
        Debug.Log("??");
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

    // Update is called once per frame
    void Update()
    {
 
        if (OKbutton.GetComponent<PointerListener>().pressed&& scanObj != null)
        {
            //Debug.Log("why???");
            Talkwith();
            OKbutton.GetComponent<PointerListener>().pressed = false;
        }

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
