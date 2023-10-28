using System.Collections.Generic;
using Data;
using Script;
using UnityEngine;

[RequireComponent(typeof(ObjectPool))]
public class EnemyTaret : MonoBehaviour
{
    public List<Transform> turretBarrels;
    public TurretData turretData;
        
    private bool canShoot = true;
    private Collider2D[] enemyColliders;
    private float currentDelay = 0;

    private ObjectPool bulletPool;
    [SerializeField]
    private int bulletPoolCount = 10;

    private void Awake()
    {
        enemyColliders = GetComponentsInParent<Collider2D>();
        bulletPool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        bulletPool.Initialize(turretData.bulletPrefab, bulletPoolCount);
   
    }

    private void Update()
    {
        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            
            if (currentDelay <= 0)
            {
                canShoot = true;
                
            }
        }
    }

    public void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            currentDelay = turretData.reloadDelay;

            foreach (var barrel in turretBarrels)
            {
                GameObject bullet = bulletPool.CreateObject();
                bullet.transform.position = barrel.position;
                bullet.transform.localRotation = barrel.rotation;
                bullet.GetComponent<Bullet>().Initialize(turretData.bulletData);

                foreach (var collider in enemyColliders)
                {
                    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider);
                }

            }

        }
    }
}