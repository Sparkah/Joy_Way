using UnityEngine;

public class Weapon : MonoBehaviour
{
    //Выбираем откуда стрелять (взависимости что сейчас находится в руке)
    public void Shoot()
    {
        if (GetComponent<ShootGun>()!=null)
        {
            GetComponent<ShootGun>().Shoot();
        }
        if (GetComponent<ShootFire>() != null)
        {
            GetComponent<ShootFire>().Shoot();
        }
        if (GetComponent<ShootWater>() != null)
        {
            GetComponent<ShootWater>().Shoot();
        }
    }
}