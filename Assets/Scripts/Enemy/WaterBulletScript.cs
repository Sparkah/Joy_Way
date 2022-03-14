using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBulletScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyModel enemyModel = other.GetComponentInParent<EnemyModel>();
            enemyModel.MakeWet(-10);
            Destroy(gameObject);
        }
    }
}
