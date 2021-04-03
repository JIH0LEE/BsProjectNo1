using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    public Animator anim;

    public enum CurrentState { idle, trace, attack };
    public CurrentState curState = CurrentState.idle;

    private Transform _transform;
    private Transform playerTransform;

    Rigidbody2D enemyRigid;
    Vector2 movement;

    public int maxHealth = 100;
    int currentHealth;

    public int enemyDamage = 10;

    public float traceDist = 6.0f;
    public float attackDist = 3.0f;

    bool isDead = false;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        enemyRigid = GetComponent<Rigidbody2D>();

        _transform = this.gameObject.GetComponent<Transform>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();

        StartCoroutine(this.CheckState());
        StartCoroutine(this.CheckStateForAction());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        anim.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("enemy died!");

        anim.SetBool("IsDead", true);
        isDead = true;

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    IEnumerator CheckState()
    {
        while(!isDead)
        {
            yield return new WaitForSeconds(0.2f);

            float dist = Vector3.Distance(playerTransform.position, _transform.position);

            if(dist < traceDist && dist > attackDist)
            {
                curState = CurrentState.trace;
            } else if (dist < attackDist)
            {
                curState = CurrentState.attack;
            } else
            {
                curState = CurrentState.idle;
            }
        }
    }

    IEnumerator CheckStateForAction()
    {
        while (!isDead)
        {
            switch (curState)
            {
                case CurrentState.idle:
                    enemyRigid.velocity = new Vector2(0,0);
                    break;
                case CurrentState.attack:
                    enemyRigid.velocity = new Vector2(0, 0);
                    break;
                case CurrentState.trace:
                    movement.x = playerTransform.position.x - _transform.position.x;
                    movement.y = playerTransform.position.y - _transform.position.y;
                    enemyRigid.velocity = movement.normalized * 3.0f;
                    break;
            }
            yield return null;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<Combat>().TakeHit(enemyDamage);
        }
    }
}
