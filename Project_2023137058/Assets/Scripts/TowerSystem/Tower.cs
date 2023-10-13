using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 3.0f;      //타워 사거리
    public float fireRate = 1.0f;   //타워 발사 간격
    public LayerMask IsEnemy;       //레이어 시스템으로 감지

    public Collider[] colliderInRange;          //사거리에 감지된 collider 배열

    public List<EnemyController> enemiesInRange = new List<EnemyController>();          //사거리 안에 있는 Enemy 컴포넌트 List

    public float checkcounter;          //시간 체크용 float
    public float checkTime = 2.0f;      //0.2마다 검출

    public bool enemiesUpdate;          //float 값으로 체크 완료했는지 검출

    // Start is called before the first frame update
    void Start()
    {
        checkcounter = checkTime;
    }

    // Update is called once per frame
    void Update()
    {
        enemiesUpdate = false;

        checkcounter -= Time.deltaTime;         //0.2-> 0초가 될 때까지 시간을 감소

        if(checkcounter <= 0 )                  //0초 이하가 되었을 때
        {   
            checkcounter = checkTime;           //0.2초로 다시 변경

            colliderInRange = Physics.OverlapSphere(transform.position, range, IsEnemy);

            enemiesInRange .Clear();

            foreach (Collider col in colliderInRange)
            {
                enemiesInRange.Add(col.GetComponent<EnemyController>());
            }

            enemiesUpdate = true;
        }
    }
}
