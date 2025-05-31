using UnityEngine;

public class EnemyBullet : Bullet
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

        timer += Time.deltaTime; // Disable bullet when timer more than or equal enemyLifetime timer will + 1f every seconds
        if (timer >= enemyLifeTime || _isOutOfScreen)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHP>().hp -= bulletDamage;
            Destroy(gameObject);
        }
    }
}
