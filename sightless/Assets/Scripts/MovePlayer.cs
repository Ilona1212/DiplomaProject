using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    static public float speed = 3.5f;
    public static int usetypeitem = -1, onlamp = -1, lamps = 1;
    public bool leftrun = false;
    public GameObject player;
    public Text textt;
    public static GameObject die;
    public GameObject death;
    public static bool changetext = false;


    void Start()
    {
        die = death;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (changetext)
        {
            textt.GetComponent<Text>().text = lamps + "/5";
            changetext = false;
        }
    }

    public static void SetLamps(bool plus)
    {
        if (plus) lamps++;
        else
        {
            if(--lamps <= 0)
            {
                Death();
            }
        }
        changetext = true;
    }
    public static void Death()
    {
        Time.timeScale = 0;
        die.SetActive(true);
        PauseMenu.pause = true;
        print("The END");
    }
}
