using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Range : Enemy
{
    private float magicRange = 3f;
    private bool _isAttack = false;
    public int RangeAct;

    public GameObject magicPrefab;
    public Transform firePoint;
    protected override void Update()
    {
        base.Update();

        if (hp <= 0)
        {
            Destroy(gameObject);
            return;
        }
        enemyAnim.SetInteger("RangeAct", RangeAct);
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= magicRange)
        {
            if(_isAttack == false) 
            {
                Aim();
                StartCoroutine(EnemyAttack());
            }
        }
        else
        {
            RangeAct = 0;
        }
    }
    IEnumerator EnemyAttack()
    {
        _isAttack = true;
        RangeAct = 1;
        yield return new WaitForSeconds(2f);
        GameObject magicEnemy = Instantiate(magicPrefab, firePoint.position, firePoint.rotation);
        magicEnemy.GetComponent<Bullet>().bulletDirection = (player.position - transform.position).normalized;
        magicEnemy.GetComponent<Bullet>().bulletDamage = damage;
        RangeAct = 0;
        _isAttack = false;
    }
    private void Aim()
    {
        Vector2 dir = player.transform.position - transform.position;
        dir.Normalize();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        firePoint.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }
}
