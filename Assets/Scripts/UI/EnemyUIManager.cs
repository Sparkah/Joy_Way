using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUIManager : MonoBehaviour
{
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.LookAt(Player.transform.position);
    }
}
