using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 2;
    public int damage = 2;
    public float sentDirection = 1;
    public bool _isFacingRight = false;

    public Transform player;
    public Rigidbody2D enemyRb2d;
    public GameObject bloodPrefab;
    [SerializeField] public Animator enemyAnim;
    [SerializeField] private SpriteRenderer enemySprite;
    protected virtual void Update()
    {
        if(hp <= 0)
        {
            GameObject prefab = Instantiate(bloodPrefab);
            prefab.transform.position = this.transform.position;
            Destroy(prefab, 0.5f);
        }
        LookForPlayer();
        if (player.position.x > transform.position.x && _isFacingRight)
        {
            Flip();
        }
        else if (player.position.x < transform.position.x && !_isFacingRight)
        {
            Flip();
        }
    }
    void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 direction = transform.localScale;
        direction.x *= -1;
        transform.localScale = direction;
        sentDirection *= -1;
    }
    void LookForPlayer()
    {
        Vector2 rayDirectionLeft = Vector2.left;
        Vector2 rayDirectionRight = Vector2.right;
    }
}
