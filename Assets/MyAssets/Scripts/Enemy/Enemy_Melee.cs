using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Melee : Enemy
{
    private float range = 2.5f;
    private float speed = 0.5f;
    private bool _isAttack = false;
    public int EnemyAct;
    public Transform startPoint;
    private void Start()
    {
        startPoint.position = transform.position;
    }
    protected override void Update()
    {
        base.Update();

        if (hp <= 0)
        {
            Destroy(gameObject); 
            return;
        }
        enemyAnim.SetInteger("EnemyAct", EnemyAct);
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer > range)
        {
            EnemyAct = 1;
            Vector2 enemyWalk = Vector2.MoveTowards(transform.position, startPoint.position, speed * Time.deltaTime);
            enemyRb2d.MovePosition(enemyWalk);
            if(transform.position == startPoint.position)
            {
                EnemyAct = 0;
            }
        }
        if (distanceToPlayer > 0.7f && distanceToPlayer <= range)
        {
            EnemyAct = 1;
            Vector2 enemyWalk = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            enemyRb2d.MovePosition(enemyWalk);
        }
        if (distanceToPlayer <= 0.7f && player.gameObject.activeSelf == true)
        {
            if(_isAttack == false)
            {
                EnemyAct = 2;
                StartCoroutine(EnemyAttack());
            }
        }
        else
        {
            EnemyAct = 0;
        }
    }
    IEnumerator EnemyAttack()
    {
        if (player.gameObject.activeSelf == true)
        {
            _isAttack = true;
            yield return new WaitForSeconds(2f);
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            if (distanceToPlayer <= 0.7f)
            {
                player.GetComponent<PlayerHP>().hp -= damage;
            }
            _isAttack = false;
        }
    }
}
