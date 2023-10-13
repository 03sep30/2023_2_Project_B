using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float range = 3.0f;      //Ÿ�� ��Ÿ�
    public float fireRate = 1.0f;   //Ÿ�� �߻� ����
    public LayerMask IsEnemy;       //���̾� �ý������� ����

    public Collider[] colliderInRange;          //��Ÿ��� ������ collider �迭

    public List<EnemyController> enemiesInRange = new List<EnemyController>();          //��Ÿ� �ȿ� �ִ� Enemy ������Ʈ List

    public float checkcounter;          //�ð� üũ�� float
    public float checkTime = 2.0f;      //0.2���� ����

    public bool enemiesUpdate;          //float ������ üũ �Ϸ��ߴ��� ����

    // Start is called before the first frame update
    void Start()
    {
        checkcounter = checkTime;
    }

    // Update is called once per frame
    void Update()
    {
        enemiesUpdate = false;

        checkcounter -= Time.deltaTime;         //0.2-> 0�ʰ� �� ������ �ð��� ����

        if(checkcounter <= 0 )                  //0�� ���ϰ� �Ǿ��� ��
        {   
            checkcounter = checkTime;           //0.2�ʷ� �ٽ� ����

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
