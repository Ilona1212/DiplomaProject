using UnityEngine;
using UnityEngine.UI;

public class HealthPoint : MonoBehaviour
{
    private static float HP = 1f;
    public static Image imageHP;
    // Start is called before the first frame update
    void Start()
    {
        imageHP = GetComponent<Image>();
    }

    public static void SetHealth(float hp, bool plus)
    {
        if (plus)
        {
            HP += hp;
            if (HP >= 1f) HP = 1f;
        }
        else
        {
            HP -= hp;
            if (HP < 0.1f)
            {
                HP = 0.1f;
                MovePlayer.Death();
            }
        }
        imageHP.fillAmount = HP;
    }
}
