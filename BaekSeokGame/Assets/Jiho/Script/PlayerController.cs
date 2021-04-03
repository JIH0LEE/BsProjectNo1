using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
   
    Rigidbody2D playerRigid;
    Vector2 movement;
    Animator anim;
    public Vector3 lookingVec;
    RaycastHit2D rayHit;
    GameObject scanObj;

    
    public GameObject OKbutton;
    public Joystick joystick;
    public DialogController dialog;
    public Combat combat;

    public float speed = 5f;
    public string currentMapName;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    
    float power;
    float x;
    float y;

    bool isPlayerOnPortal;

   

    string transferMapName;

   

    public Portal portal;

    public void Talkwith()
    {

        

        if(scanObj == null)
        {
            
            return;
        }
        //else if (scanObj.layer == LayerMask.NameToLayer("Npc"))
        // {
        //     dialog.Action(scanObj);
        // }
        else if (scanObj.tag =="npc")
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


    static bool onLoad=false;
    void Start()
    {
        anim = GetComponent<Animator>();
        playerRigid = GetComponent<Rigidbody2D>();
        combat = gameObject.GetComponent<Combat>();
        power = 5.0f ;
        isPlayerOnPortal = false;

        if (!onLoad) 
        {
            this.transform.position = new Vector3(DataController.Instance.gameData.playerX, DataController.Instance.gameData.playerY, 0);
            SceneManager.LoadScene(DataController.Instance.gameData.currentMap);
            onLoad = true;
            
        }
       




    }
   


    void Update()
    {
 
        //if (OKbutton.GetComponent<PointerListener>().pressed&& scanObj != null)
        //{
            
        //    Talkwith();
        //    OKbutton.GetComponent<PointerListener>().pressed = false;
        //}
            
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;


    }
    
       
    
    void FixedUpdate()
    {
        


        playerRigid.velocity = movement * speed;
        x = movement.x;
        y = movement.y;
        PlayerDir(x, y);
        //마지막으로 바라본 방향 애니메이션 유지하게 함
        if (movement != Vector2.zero)
        {
            anim.SetFloat("Horizontal", movement.x);
            anim.SetFloat("Vertical", movement.y);
        }
        anim.SetFloat("Speed", movement.sqrMagnitude);


        DataController.Instance.gameData.playerX = this.transform.position.x;
        DataController.Instance.gameData.playerY = this.transform.position.y    ;


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
    void OnTriggerEnter2D(Collider2D Object)
    {

        //Debug.Log(Object.gameObject);

        if (Object.tag == "portals")
        {

            isPlayerOnPortal = true;
            portal = Object.gameObject.GetComponent<Portal>();
        }
        //if (Object.tag == "npc")
        //{
        //    isPlayerOnNPC = true;
        //}

    }
    void OnTriggerExit2D(Collider2D Object)
    {

        if (Object.tag == "portals")
        {
            isPlayerOnPortal = false;
            portal = null;
        }
        //if (Object.tag == "npc")
        //{
        //    isPlayerOnNPC = false;
        //}

    }
    public void Click()
    {
      
        if (isPlayerOnPortal == true)
            
        {
            Debug.Log("err");
            Portal();
        }
        else if (scanObj!=null&&scanObj.tag!=null)
        {
         
            Talkwith();
          
        } 
        else
        {
            if(Time.time >= nextAttackTime)
            {
                AttackAnimation();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            
            
        }
    }

    public void Portal()
    {
       
        SceneManager.LoadScene(portal.nextMap);
        DataController.Instance.gameData.currentMap = portal.nextMap;
        this.transform.position = portal.nextPosition;
    }

    public void AttackAnimation()
    {
        anim.SetTrigger("Attack");
        combat.Attack();
    }
    //public void Talk()
    //{
    //    Debug.Log("npc click");
    //}


}
