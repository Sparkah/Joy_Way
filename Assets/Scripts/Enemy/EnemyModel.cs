using System;
using System.Collections;
using UnityEngine;

internal interface IEnemyModel
{
    void TakeDamage(int damage, int duration);
    void MakeWet(int wetness);
    void RestoreHP();
    void CatchFire();
    void DestroyOpponent();
}

public class EnemyModel : MonoBehaviour, IEnemyModel
{
    private void OnEnable()
    {
        ParticleSystemDetectPlayer.FireCatch += CatchFire;
    }

    private void OnDisable()
    {
        ParticleSystemDetectPlayer.FireCatch -= CatchFire;
    }

    private int hp = 1000;
    private int wet = 0; //0 = без эффекта, <0 = намок, 1 = горит

    public delegate void Damaged();
    public static event Damaged OnDamage;

    public delegate void HP(int hp);
    public static event HP ShowHP;

    public delegate void Wet(int wet);
    public static event Wet ShowWetness;
    private bool onFire;

    private int damageAmount; // Дополнительный урон взависимости от состояния чучела

    //Обрабатываем получаемый урон
    public void TakeDamage(int damage, int duration)
    {
        if (GameObject.FindObjectOfType<GunBulletScript>() != null)
        {
            if (wet > 0)
                damageAmount = 10;
            if (wet < 0)
                damageAmount = -10;
            if (wet == 0)
                damageAmount = 0;
        }
        else
            damageAmount = 0;

        StartCoroutine(TakeDamageOverTime(damage, duration));
    }

    //Корутина для получения урона несколько секунд подряд
    IEnumerator TakeDamageOverTime(int damage, int duration)
    {
        hp -= damage + damageAmount;
        if (hp < 0)
        {
            DestroyOpponent();
        }
        ShowHP(hp);
        yield return new WaitForSeconds(1f);
        duration -= 1;
        if (duration > 0 && wet >= 0)
            StartCoroutine(TakeDamageOverTime(damage, duration));
    }

    public void MakeWet(int wetness)
    {
        wet += wetness;
        if (wet > 100)
            wet = 100;

        ShowWetness(wet);
    }

    public void CatchFire()
    {
        wet += 1;
        if (wet < 0)
        {
            TakeDamage(1, 1);
        }
        if (wet >= 0) // максимальное горение = 1. Сразу тушится водой при попадении
        {
            wet += 1;
            if (wet > 1)
            {
                wet = 1;
            }

            if (onFire == false)
            {
                TakeDamage(5, 10);
                onFire = true;
                StartCoroutine(ResetFirePossible());
            }
            if (onFire == true)
            {
                TakeDamage(1, 1);
            }
        }

        ShowHP(hp);
        ShowWetness(wet);
    }

    IEnumerator ResetFirePossible() // Снова можно гореть, когда прогорит 10 сек
    {
        yield return new WaitForSeconds(10f);
        onFire = false;
        wet = 0;
    }

    public void DestroyOpponent()
    {
        Destroy(gameObject);
    }

    public void RestoreHP()
    {
        hp = 1000;
    }
}