using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBulletScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("Enemy"))
        {
            EnemyModel enemyModel = other.GetComponentInParent<EnemyModel>();
            enemyModel.TakeDamage(20, 1);
            Destroy(gameObject);
        }
    }
}