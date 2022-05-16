using System.Collections;
using UnityEngine;

public class EnemyFunction : MonoBehaviour
{
    public int enemyid = 0;
    
    private bool[] fightenemy = { false, false, false, false, false };
    public AudioClip[] fightsound;
    public AudioSource fsound;
    static public int buttonforwon = 4;
    public GameObject enemybot;

    public GameObject[] icons;
    public GameObject icon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!fightenemy[enemyid] && !GameController.enemydefeat[enemyid]) //  && UseButton.fuel <= 0f
        {
            enemybot = (GameObject)Instantiate(Resources.Load("enemy"));
            enemybot.transform.position = new Vector2(GameController.EnemyPos[enemyid, 0], GameController.EnemyPos[enemyid, 1]+3f); // 
            fightenemy[enemyid] = true;
            StartCoroutine(FightReset(enemyid));
            StartCoroutine(FightIcon(enemyid));
            int rand = Random.Range(1, 4);
            buttonforwon = rand; //
            icon = icons[rand - 1];
            fsound.clip = fightsound[rand - 1];
            fsound.Play();
            blackscreen.blackgo = 1;
            UseButton.fightid = enemyid;
            print("Вошел в зону " + enemyid);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (fightenemy[enemyid])
        {
            Destroy(enemybot);
            fightenemy[enemyid] = false;
            buttonforwon = 4;
            UseButton.fightid = -1;
            print("Вышел из зоны " + enemyid);
        }
    }

    IEnumerator FightReset(int enemy)
    {
        yield return new WaitForSeconds(2f);
        Destroy(enemybot);//enemybot.SetActive(false);
        fightenemy[enemy] = false;
        buttonforwon = 4;
        blackscreen.blackgo = 2;
        if(!GameController.enemydefeat[enemy])
        {
            HealthPoint.SetHealth(0.35f, false);
        }
        icon.SetActive(false);
    }
    IEnumerator FightIcon(int enemy)
    {
        yield return new WaitForSeconds(1f);
        icon.SetActive(true);
    }
}
