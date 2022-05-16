using UnityEngine;
//using UnityEngine.UI;

public class BallonUse : MonoBehaviour
{
    public GameObject icon, ballonlight, player;
    public int BallonID = 0, PlayerBallon = -1;
    public Vector2 startpos, endpos, playerendpos, playerstartpos;
    public bool useballon = false, ballonright = false;
    private float progress;

    private void Start()
    {
        playerstartpos = new Vector2(startpos.x, startpos.y - 2f);
        playerendpos = new Vector2(endpos.x, endpos.y - 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ActionItem.item = this.gameObject;
        MovePlayer.usetypeitem = 2;
        PlayerBallon = BallonID;
        icon.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        MovePlayer.usetypeitem = -1;
        PlayerBallon = -1;
        icon.SetActive(false);
    }

    private void FixedUpdate()
    {
        if(useballon)
        {
            if (!ballonright)
            {
                transform.position = Vector2.Lerp(startpos, endpos, progress);
                player.transform.position = Vector2.Lerp(playerstartpos, playerendpos, progress);
            }
            else
            {
                transform.position = Vector2.Lerp(endpos, startpos, progress);
                player.transform.position = Vector2.Lerp(playerendpos, playerstartpos, progress);
            }
            progress += 0.0025f;
            player.GetComponent<Rigidbody2D>().gravityScale = 0;
            if (progress >= 1f)
            {
                progress = 0;
                useballon = false;
                ballonlight.SetActive(false);
                if (!ballonright) player.transform.position = new Vector2(endpos.x + 2f, endpos.y - 2f);
                else player.transform.position = new Vector2(startpos.x - 2f, startpos.y - 2f);
                player.GetComponent<Rigidbody2D>().gravityScale = 3;
                ballonright = !ballonright;
            }
        }
    }
}
