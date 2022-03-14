using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerView playerView;
    private void Start()
    {
        playerView = GetComponent<PlayerView>();
    }

    // Обрабатываем пользовательский ввод
    private float moveDir;
    [SerializeField] float speed = 0.1f;
    [SerializeField] float horizontalMouseSpeed = 10.0f;
    [SerializeField] float verticalMouseSpeed = 40.0f;
    private float horizontalRotationSpeed;
    private float verticalRotationSpeed;
    private bool rightArm;
    private void Update()
    {
        //Вперед назад
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            moveDir = Input.GetAxis("Vertical");
        }
        else
        {
            moveDir = 0;
        }

        //Вращение мышкой горизонталь
        horizontalRotationSpeed = Input.GetAxis("Mouse X") * horizontalMouseSpeed;
        //Вращение мышкой горизонталь
        verticalRotationSpeed = Mathf.Clamp(Input.GetAxis("Mouse Y") * verticalMouseSpeed, -0.85f,0.85f);

        //Поднять оружие
        if (Input.GetKeyDown(KeyCode.Q))
        {
            playerView.PickWeapon(rightArm);
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerView.PickWeapon(!rightArm);
        }

        //Стрелять оружием
        if(Input.GetMouseButtonDown(0))
        {
            playerView.ShootWeapon(rightArm);
        }
        if (Input.GetMouseButtonDown(1))
        {
            playerView.ShootWeapon(!rightArm);
        }
    }

    //Применяем физику к пользовательскому вводу
    private void FixedUpdate()
    {
        //Движение вперед назад
        transform.Translate(transform.forward*moveDir*speed, Space.World);
        //Вращение влево вправо
        transform.Rotate(0, horizontalRotationSpeed, 0);
        //Вращение вверх вниз
        playerView.MoveHandsToPointer(-verticalRotationSpeed);
        //Camera.main.transform.Rotate(-verticalRotationSpeed, 0, 0);
    }
}