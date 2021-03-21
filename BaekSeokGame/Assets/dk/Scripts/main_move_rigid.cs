using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_move_rigid : MonoBehaviour
{
    public Joystick joystick;

    public Rigidbody2D rb;

    public float speed = 5f;

    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement.x = joystick.Horizontal;
        movement.y = joystick.Vertical;
    }


    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }

}
