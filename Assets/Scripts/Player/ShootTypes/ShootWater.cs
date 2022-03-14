using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWater : MonoBehaviour
{
    [SerializeField] GameObject waterBullet;
    private int force = 800;
    internal void Shoot()
    {
        Rigidbody Bullet = Instantiate(waterBullet, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
        Bullet.AddForce(-transform.right * force, ForceMode.Force);
        StartCoroutine(DestroyBullet(Bullet));
    }

    //Можно использовать Object Pool для оптимизации производительности
    IEnumerator DestroyBullet(Rigidbody Bullet)
    {
        yield return new WaitForSeconds(5f);
        if(Bullet!=null)
        Destroy(Bullet.gameObject);
    }
}
