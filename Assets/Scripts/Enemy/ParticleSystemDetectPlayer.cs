using UnityEngine;

public class ParticleSystemDetectPlayer : MonoBehaviour
{
    public delegate void Fire();
    public static event Fire FireCatch;
    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Enemy")
        {
            FireCatch();
        }
    }
}