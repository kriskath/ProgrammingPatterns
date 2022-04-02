using System;
using UnityEngine;
using UnityEngine.Pool;

public class Launcher : MonoBehaviour 
{

    [SerializeField] Bullet bulletPrefab;
    private IObjectPool<Bullet> bulletPool;

    private void Awake()
    {
        bulletPool = new ObjectPool<Bullet>(
            CreateBullet,
            OnGet,
            OnRelease,
            OnDestroyBullet,
            maxSize:3);
    }



    private Bullet CreateBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab); //create
        bullet.SetPool(bulletPool); //set pool
        return bullet;
    }

    private void OnGet(Bullet bullet)
    {
        bullet.gameObject.transform.position = this.transform.position;
        bullet.gameObject.SetActive(true);
    }

    private void OnRelease(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    private void OnDestroyBullet(Bullet bullet)
    {
        Destroy(bullet.gameObject);
    }

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletPool.Get();
        }
    }
}