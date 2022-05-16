using UnityEngine;
//using UnityEngine.UI;
using System.Collections;

public class UseButton : MonoBehaviour
{
    // Start is called before the first frame update
    public int IDButton;
    public GameObject player, light;
    public static GameObject lighter;
    public static int fightid = -1;
    public static float fuel = 1f;
    private bool buttonuse = false;
    private Animator anim;

    void Start()
    {
        lighter = light;
        anim = player.GetComponent<Animator>();
    }
    void OnMouseDown()
    {
        if (!PauseMenu.pause && fightid != -1)
        {
            if (EnemyFunction.buttonforwon != 4 && !buttonuse)
            {
                if (EnemyFunction.buttonforwon == IDButton)
                {
                    if (fuel <= 0f)
                    {
                        int range = Random.Range(0, 100);
                        if (range < 21)
                        {
                            HealthPoint.SetHealth(0.1f, false);
                            print("Не повезло");
                        }
                        else
                        {
                            GameController.enemydefeat[fightid] = true;
                            print("Враг повержен");
                            anim.SetBool("IsAttack", true);
                        }
                    }
                    else
                    {
                        GameController.enemydefeat[fightid] = true;
                        print("Враг повержен");
                        anim.SetBool("IsAttack", true);
                    }

                }
            }
            else
            {
                HealthPoint.SetHealth(0.1f, false);
            }
            buttonuse = true;
            StartCoroutine(ResetButton());
            /*switch (IDButton)
            {
                case 1:
                {
                    print("click 1");
                    //HealthPoint.SetHealth(0.1f, false);
                    break;
                }
                case 2:
                {
                    print("click 2");
                    //HealthPoint.SetHealth(0.1f, true);
                    break;
                }
                case 3:
                {
                    print(player.transform.position);
                    break;
                }
            }*/
        }
    }
    IEnumerator ResetButton()
    {
        yield return new WaitForSeconds(2f);
        buttonuse = false;
        anim.SetBool("IsAttack", false);
    }

    public static void SetFuel(float f, bool plus)
    {
        if (plus)
        {
            if (fuel <= 0f && !lighter.activeSelf)
            {
                fuel += f; //
                MovePlayer.SetLamps(true);
                lighter.SetActive(true);
            }
            if (fuel > 1f) fuel = 1f;
        }
        else
        {
            fuel -= f;
            if (fuel < 0f && lighter.activeSelf)// 
            {
                fuel = 0f;
                MovePlayer.SetLamps(false);
                lighter.SetActive(false);
            }
        }
    }
}