using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ProjectlieTower : MonoBehaviour
{
    private Tower thisTower;                                //���� ������Ʈ �ȿ� �ִ� ������Ʈ Tower�� ����

    public GameObject projectile;
    public Transform firepoint;
    public float timeBetweenShot = 1.0f;

    private float shotcounter;

    private Transform target;
    public Transform launcherModel;

    // Start is called before the first frame update
    void Start()
    {
        thisTower = GetComponent<Tower>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)                                 //Ÿ���� ���� ���
        {
            launcherModel.rotation =
                 Quaternion.Slerp(launcherModel.rotation,                                   //���ʹϾ� ��
                 Quaternion.LookRotation(target.position - transform.position), 
                 5f * Time.deltaTime);

            launcherModel.rotation = Quaternion.Euler(
                0.0f,
                launcherModel.rotation.eulerAngles.y,
                0.0f);

        }

        shotcounter -= Time.deltaTime;

        if(shotcounter <= 0.0f && target != null)
        {
            shotcounter = thisTower.fireRate;

            firepoint.LookAt(target);

            Instantiate (projectile , firepoint .position, firepoint .rotation);
        }

        if(thisTower.enemiesUpdate)
        {
           if(thisTower.enemiesInRange .Count > 0)
            {
                float minDistance = thisTower.range + 1f;
                foreach(EnemyController enemy in thisTower.enemiesInRange)
                {
                    if(enemy != null)
                    {
                        float distance = Vector3.Distance (transform.position , enemy.transform.position);

                        if(distance < minDistance)
                        {
                            minDistance = distance;
                            target = enemy.transform;
                        }
                    }
                }
            }
           else
            {
                target = null;
            }
        }
    }
}