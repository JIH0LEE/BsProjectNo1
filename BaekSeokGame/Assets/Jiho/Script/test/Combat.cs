using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//전투 관련 스크립트
//애니메이션 문제도 있고 버튼이랑도 관련있어서 
//어느정도 완성되면 싹다 갈아엎으면서 관계 정리좀 해야할듯

public class Combat : MonoBehaviour
{
    public GameObject gameover; // 게임오버에 써놓은 대로 지금은 별 의미 없음
    public PlayerController playerController;

    public LayerMask enemyLayers;
    public Transform attackPoint;

    public float attackRange = 0.5f;
    public Vector2 attackPosition = new Vector2(0f,0f);

    public bool isInvulnerable = false;

    

        
    public int maxHealth = 100; 
    public int currentHealth;
    public int attackDamage = 35;

    public healthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0)
        {
            gameover.SetActive(true);
        } else
        {
            gameover.SetActive(false);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

        SetAttackPosition();
        
        
    }

    void SetAttackPosition()
    {
        attackPoint.localPosition = playerController.lookingVec * 0.35f;
    }

    public void Attack()
    {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("HIT" + enemy.name);

            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    //cc기나 속성 데미지같은걸 입었을때 처리 차이 두기 위해서 TakeDamage와 구분
    //현재는 미구현이라 그냥 takedamage랑 똑같다고 보면 됨
    public void TakeHit(int damage)
    {

        
        if (isInvulnerable == true)
        {
            return;
        }
        TakeDamage(damage);

        StartCoroutine(BecomeInvulnerabale());
        
    }

    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    //무적시간을 처리함
    private IEnumerator BecomeInvulnerabale()
    {
        Debug.Log("invulnerable on");
        isInvulnerable = true;

        yield return new WaitForSeconds(1);

        isInvulnerable = false;
        Debug.Log("invulnerable off");
    }


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
