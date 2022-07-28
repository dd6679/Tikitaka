using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NK_Enemy : MonoBehaviour
{
    public float range = 10f;
    public float speed = 5f;
    public bool isRunning = false;
    public bool isDying = false;

    private Transform target;
    Animator enemyAnimator;
    // Start is called before the first frame update

    void Start()
    {
        target = GameObject.Find("Player").transform;
        enemyAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // ���� �Ÿ� �ȿ� ������ �ٰ��ͼ� ��Ŭ�ϵ���
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= range && !isDying)
        {
            enemyAnimator.SetBool("IsRunning", true);
            // �÷��̾� �������� x, z��ǥ�� �����̵��� �� (���� X)
            Vector3 targetDirection = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z);
            Vector3 direction = targetDirection - transform.position;
            direction.Normalize();
            transform.LookAt(2 * transform.position - targetDirection);
            transform.position += direction * speed * Time.deltaTime;
        }
        else
        {
            enemyAnimator.SetBool("IsRunning", false);
        }

         if(transform.up.y <= 0)
        {
            isDying = true;
            enemyAnimator.SetBool("IsDying", isDying);
        }
    }
}
