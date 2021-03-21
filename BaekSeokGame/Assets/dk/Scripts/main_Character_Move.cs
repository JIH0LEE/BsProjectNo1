using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_Character_Move : MonoBehaviour
{

    public Joystick joystick;

    //public Animator animator;

    int speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   

    // Update is called once per frame
    void Update()
    {
        float xMove = joystick.Horizontal * speed * Time.deltaTime; //x축으로 이동할 양
        float yMove = joystick.Vertical * speed * Time.deltaTime; //y축으로 이동할양

        float isMove = 0;

        if (joystick.Horizontal < 0.2f && joystick.Horizontal > -0.2f)
        {
            xMove = 0;
        }
        if (joystick.Vertical < 0.2f && joystick.Vertical > -0.2f)
        {
            yMove = 0;
        }
        if (xMove != 0 || yMove != 0)
        {
            isMove = 1;
        }

        //animator.SetFloat("horizontal", xMove);
        //animator.SetFloat("vertical", yMove);
        //animator.SetFloat("speed", isMove);

        this.transform.Translate(new Vector3(xMove, yMove, 0));  //이동
    }
}
