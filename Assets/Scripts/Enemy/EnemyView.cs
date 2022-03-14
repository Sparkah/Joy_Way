using UnityEngine;
using UnityEngine.UI;

public class EnemyView : MonoBehaviour
{
    private void OnEnable()
    {
        EnemyModel.ShowHP += DisplayHp;
        EnemyModel.ShowWetness += DisplayWetness;
    }

    private void OnDisable()
    {
        EnemyModel.ShowHP -= DisplayHp;
        EnemyModel.ShowWetness -= DisplayWetness;
    }

    [SerializeField] Text hP;
    [SerializeField] Text wetness;

    private float adjustTextHpHeight = 5.5f;

    private Material material; //Идея менять цвет материала взависимости от значения wet в EnemyModel. Если 1, делать красный оттенок, а если меньше 0, синий.

    private void Start()
    {
        hP.text = 1000.ToString();
        wetness.text = 0.ToString(); // Задаем начальные значения влажности и здоровья

        hP.transform.position = transform.position + new Vector3 (0,adjustTextHpHeight,0);
        wetness.transform.position = transform.position + new Vector3(0, adjustTextHpHeight + 0.75f, 0);
    }

    public void DisplayHp(int hp)
    {
        hP.text = hp.ToString();
    }

    public void DisplayWetness(int wet)
    {
        wetness.text = wet.ToString();
    }
}