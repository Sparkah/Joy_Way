using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyModel enemyModel;
    private void Start()
    {
        enemyModel = GetComponent<EnemyModel>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            enemyModel.RestoreHP();
        }
    }
}