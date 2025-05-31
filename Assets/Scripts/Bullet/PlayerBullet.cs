using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    private void OnEnable()
    {
        timer = 0f;
    }
    private void Update()
    {
        Vector2 bulletWorldToViewportPos = Camera.main.WorldToViewportPoint(transform.position);
        bool _isOutOfScreen = bulletWorldToViewportPos.x < 0 || bulletWorldToViewportPos.x > 1 || bulletWorldToViewportPos.y < 0 || bulletWorldToViewportPos.y > 1;

        transform.Translate(bulletDirection.normalized * speed * Time.deltaTime, Space.World);

        timer += Time.deltaTime;
        if (timer >= lifeTime || _isOutOfScreen)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Enemy"))
        {
            collision.GetComponent<Enemy>().hp -= bulletDamage;
            gameObject.SetActive(false);
        }
    }
}
