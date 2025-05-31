using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public GameObject magic_Prefab;
    public int poolSize = 5;
    private List<GameObject> pool = new List<GameObject>();
    private void Start()
    {
        for(int i = 0; i < poolSize; i++) 
        {
            GameObject bullet = Instantiate(magic_Prefab);
            bullet.SetActive(false);
            pool.Add(bullet);
        }
    }
    public GameObject ActiveBullet()
    {
        foreach(GameObject bullet in pool) 
        {
            if(!bullet.activeInHierarchy)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }
        return null;
    }
}
