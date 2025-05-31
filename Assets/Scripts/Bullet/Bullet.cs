using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifeTime = 2f;
    public float timer;
    public Rigidbody2D bulletRb2d;
    public int bulletDamage = 1;
    public Vector2 bulletDirection;
}
