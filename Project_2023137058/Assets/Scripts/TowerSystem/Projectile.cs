using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rb;                               //물리 강체 선언

    public float moveSpeed;
    public float damagedAmount;
    private bool hasDamaged;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();                 //시작할 때 강체를 가져온다.
        rb.velocity = transform.forward * moveSpeed;    //시작할 때 해당 물체 앞쪽 방향으로 MoveSpeed 만큼의 속도를 입력
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && !hasDamaged)
        {
            hasDamaged = true;
        }

        Destroy(gameObject);
    }
}
