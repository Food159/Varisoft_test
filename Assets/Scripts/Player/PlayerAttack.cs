using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private InputActionAsset inputAction;
    private InputAction actionAttack;
    private InputAction actionMove;

    public BulletPool bulletpool;
    public Transform firePoint;
    private Vector2 moveDir;

    public bool _isCooldown = false;
    private void Awake()
    {
        actionAttack = inputAction.FindAction("Player_Attack");
        actionMove = inputAction.FindAction("Player_Walk");
    }
    private void OnEnable()
    {
        actionAttack.Enable();
        actionMove.Enable();
    }
    private void OnDisable()
    {
        actionAttack.Disable();
        actionMove.Disable();
    }
    private void Update()
    {
        moveDir = actionMove.ReadValue<Vector2>();

        if (moveDir.magnitude > 0.01f)
        {
            float angle = Mathf.Atan2(moveDir.y, moveDir.x) * Mathf.Rad2Deg;
            firePoint.rotation = Quaternion.Euler(0, 0, angle - 90f);
        }
        if (actionAttack.WasPressedThisFrame())
        {
            if(_isCooldown == false)
            {
                Attack();
                StartCoroutine(CooldownMagic());
            }
        }
    }
    public IEnumerator CooldownMagic() // Cooldown
    {
        _isCooldown = true;
        yield return new WaitForSeconds(0.5f);
        _isCooldown = false;
    }
    void Attack()
    {
        GameObject bullet = bulletpool.ActiveBullet();
        if(bullet != null) 
        {
            bullet.transform.position = firePoint.position;
            bullet.transform.rotation = firePoint.rotation;
            Vector2 dir = firePoint.up;
            bullet.GetComponent<Bullet>().bulletDirection = dir;
            bullet.SetActive(true);
        }
    }
}
