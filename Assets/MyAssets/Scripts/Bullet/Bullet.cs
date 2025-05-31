using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime = 2f;
    public float enemyLifeTime = 5f;
    public float timer;
    public Rigidbody2D bulletRb2d;
    public int bulletDamage = 1;
    public Vector2 bulletDirection;
}
