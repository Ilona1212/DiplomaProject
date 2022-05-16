using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IconScript : MonoBehaviour
{
    public GameObject[] icons;
    public GameObject icon, lamplight;
    public int typeicon = 0, lampid = 0;
    public Sprite[] lampuse;
    public static bool[] lampon = { false, false, false, false, false, false };
    public static int[] timer = { 30, 30, 30, 30, 30, 30 };
    private bool check = false;


    void Start()
    {
        icon = icons[typeicon];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovePlayer.usetypeitem = 1;
        MovePlayer.onlamp = lampid;
        icon.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        MovePlayer.usetypeitem = MovePlayer.onlamp = -1;
        icon.SetActive(false);
    }

    void Update()
    {
        if(lampon[lampid] == true && !check)
        {
            GetComponent<SpriteRenderer>().sprite = lampuse[1];
            lamplight.SetActive(true);
            StartCoroutine(LampOff());
            check = true;
        }
    }

    IEnumerator LampOff()
    {
        yield return new WaitForSeconds(1f);
        if(--timer[lampid] <= 0)
        {
            GetComponent<SpriteRenderer>().sprite = lampuse[0];
            lamplight.SetActive(false);
            MovePlayer.SetLamps(false);
            lampon[lampid] = check = false;
            timer[lampid] = 30;
        }
        else StartCoroutine(LampOff());
    }
}
