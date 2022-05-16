using UnityEngine;

public class ItemTrigger : MonoBehaviour
{
    //public static float[,] ItemPos = { { 14.4f, -2.5f }, { 26.9f, -2.5f } };
    public static bool[] itemdefeat = { false, false, false, false };
    public int itemid = 0;
    public static int onitem = -1, founditem = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ActionItem.item = this.gameObject;
        onitem = itemid;
        MovePlayer.usetypeitem = 0;
        //print("Вошел");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onitem = -1;
        MovePlayer.usetypeitem = -1;
    }
}
