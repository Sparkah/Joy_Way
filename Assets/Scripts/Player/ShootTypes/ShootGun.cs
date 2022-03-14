using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootGun : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    private int force = 1500;
    internal void Shoot()
    {
        Rigidbody Bullet = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        Bullet.AddForce(-transform.right*force, ForceMode.Force);
        StartCoroutine(DestroyBullet(Bullet));
    }

    //Можно использовать Object Pool для оптимизации производительности
    IEnumerator DestroyBullet(Rigidbody Bullet)
    {
        yield return new WaitForSeconds(1f);
        if (Bullet != null)
        Destroy(Bullet.gameObject);
    }
}
