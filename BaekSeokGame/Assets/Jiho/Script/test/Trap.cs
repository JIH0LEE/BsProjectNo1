using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{

    Rigidbody2D trapRigid;
    public int trapDamage = 1;
    // Start is called before the first frame update
    void Start()
    {
        trapRigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //현재 이유는 모르겠는데, 플레이어가 움직일때만 이 ontriggerstay가 호출되고 정지해있을땐 체크가 안됨
    //검색했을때 같은 사례 많은거 보면 흔한 문제같긴 한데 해결법은 보류
    void OnTriggerStay2D(Collider2D Object)
    {

        //Debug.Log(Object.gameObject);
        
        if (Object.CompareTag("Player"))
        {
            
            Object.GetComponent<Combat>().TakeHit(trapDamage);
        }
        //if (Object.tag == "npc")
        //{
        //    isPlayerOnNPC = true;
        //}

    }
}
