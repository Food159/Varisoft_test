using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fly : Enemy
{
    private float range = 4f;
    private float speed = 1f;
    private bool _isAttack = false;
    protected override void Update()
    {
        base.Update();

        if (hp <= 0)
        {
            Destroy(gameObject);
            return;
        }
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer > 0.7f && distanceToPlayer <= range)
        {
            Vector2 enemyWalk = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            enemyRb2d.MovePosition(enemyWalk);
        }
        else if (distanceToPlayer <= 0.7f)
        {
            if (_isAttack == false)
            {
                StartCoroutine(EnemyAttack());
            }
        }
    }
    IEnumerator EnemyAttack()
    {
        _isAttack = true;
        yield return new WaitForSeconds(1f);
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if (distanceToPlayer <= 0.7f)
        {
            player.GetComponent<PlayerHP>().hp -= damage;
        }
        _isAttack = false;
    }
}
