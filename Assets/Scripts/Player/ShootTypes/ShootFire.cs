using System;
using UnityEngine;

public class ShootFire : MonoBehaviour
{
    [SerializeField] GameObject fireBullet;
    public new ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = GetComponentInChildren<ParticleSystem>();
    }
    internal void Shoot()
    {
        if (particleSystem == null)
        {
            Instantiate(fireBullet, transform.position, Quaternion.identity, transform);
            return;
        }
    }
}