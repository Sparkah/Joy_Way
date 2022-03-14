using System;
using UnityEngine;

internal interface IPlayerView
{
    void PickWeapon(bool rightArm);
    void ShootWeapon(bool rightArm);
    void MoveHandsToPointer(float vertical);
}

public class PlayerView : MonoBehaviour, IPlayerView
{
    [SerializeField] GameObject leftArmObj;
    [SerializeField] GameObject rightArmObj;

    private bool leftArmEquipped;
    private bool rightArmEquipped;

    //Метод для поднятия и сброса оружия
    // rightArm = правая !rightArm = левая
    //Большой метод можно разбить на несколько маленьких если будут дополнительные настройки взаимодействия с оружием
    public void PickWeapon(bool rightArm)
    {
        if (leftArmEquipped == true && !rightArm)
        {
            //Debug.Log("Unequip left Arm");
            GameObject WeaponInHand = leftArmObj.GetComponentInChildren<Weapon>().gameObject;
            WeaponInHand.transform.parent = null;
            leftArmEquipped = false;
            return;
        }

        if (rightArmEquipped == true && rightArm)
        {
            //Debug.Log("Unequip right Arm");
            GameObject WeaponInHand = rightArmObj.GetComponentInChildren<Weapon>().gameObject;
            WeaponInHand.transform.parent = null;
            rightArmEquipped = false;
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Transform objectHit = hit.transform;

            if (objectHit.GetComponent<Weapon>()!=null)
            {
                if(rightArm)
                {
                    //Debug.Log("Equip right Arm");
                    if (rightArmEquipped == false)
                    {
                        objectHit.transform.position = rightArmObj.transform.position + new Vector3(0, 0.1f, 0.1f);
                        objectHit.SetParent(rightArmObj.transform);
                        objectHit.transform.localEulerAngles = new Vector3(0, 90, 0);
                        rightArmEquipped = true;
                    }
                }
                if(!rightArm)
                {
                    //Debug.Log("Equip left Arm");
                    if (leftArmEquipped == false)
                    {
                        objectHit.transform.position = leftArmObj.transform.position + new Vector3(0, 0.1f, 0.1f);
                        objectHit.SetParent(leftArmObj.transform);
                        objectHit.transform.localEulerAngles = new Vector3(0, 90, 0);
                        leftArmEquipped = true;
                    }
                }
            }
        }
    }

    //Стрельба из оружия
    public void ShootWeapon(bool rightArm) // rightArm = правая !rightArm = левая
    {
        if(!rightArm && leftArmEquipped==true)
        {
            leftArmObj.GetComponentInChildren<Weapon>().Shoot();
        }
        if(rightArm && rightArmEquipped ==true)
        {
            rightArmObj.GetComponentInChildren<Weapon>().Shoot();
        }
    }

    //Повернуть руки вверх/вниз
    public void MoveHandsToPointer(float vertical)
    {
        leftArmObj.transform.Rotate(vertical, 0, 0);
        rightArmObj.transform.Rotate(vertical, 0, 0);
    }
}