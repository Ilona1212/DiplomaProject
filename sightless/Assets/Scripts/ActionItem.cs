using UnityEngine;

public class ActionItem : MonoBehaviour
{
    public static GameObject item;
    public GameObject WinGame;
    void OnMouseUp()
    {
        switch (MovePlayer.usetypeitem)
        {
            case -1: break;
            case 0: // Детали часов
            {
                if (ItemTrigger.onitem != -1 && !ItemTrigger.itemdefeat[ItemTrigger.onitem])
                {
                    //UseButton.SetFuel(0.25f, true);
                    ItemTrigger.itemdefeat[ItemTrigger.onitem] = true;
                    item.SetActive(false);
                    ItemTrigger.founditem++;
                    //print("Подобрал часі " + ItemTrigger.founditem);
                }
                break;
            }
            case 1: // Лампа
            {
                if (!IconScript.lampon[MovePlayer.onlamp])
                {
                    if (UseButton.fuel > 0)
                    {
                        if (MovePlayer.onlamp == 5) // WIN
                        {
                            WinGame.SetActive(true);
                            Time.timeScale = 0;
                            PauseMenu.pause = true;
                        }
                        IconScript.lampon[MovePlayer.onlamp] = true;
                        UseButton.fuel = 1f;
                        IconScript.timer[MovePlayer.onlamp] = 30;
                        MovePlayer.SetLamps(true);
                    }
                }
                else
                {
                    IconScript.timer[MovePlayer.onlamp] = 30;
                    if (UseButton.fuel > 0) UseButton.fuel = 1f;
                    else UseButton.SetFuel(1f, true);
                }
                break;
            }
            case 2: // Воздушный шар
            {
                int ballon = item.GetComponent<BallonUse>().PlayerBallon;
                if (ballon != -1)
                {
                    item.GetComponent<BallonUse>().ballonlight.SetActive(true);
                    item.GetComponent<BallonUse>().useballon = true;
                    item.GetComponent<BallonUse>().icon.SetActive(false);
                    if (UseButton.fuel > 0) UseButton.fuel = 1f;
                    else UseButton.SetFuel(1f, true);
                    //item.transform.position
                }
                break;
            }
        }
    }
}
