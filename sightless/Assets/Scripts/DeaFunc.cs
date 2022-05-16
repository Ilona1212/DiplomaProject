using UnityEngine;
using UnityEngine.SceneManagement;

public class DeaFunc : MonoBehaviour
{
    public int type = 0;

    void OnMouseUp()
    {
        ItemTrigger.founditem = 0;
        HealthPoint.SetHealth(1f, true);
        UseButton.fuel = 1f;
        MovePlayer.lamps = 1;
        Time.timeScale = 1;
        PauseMenu.pause = false;
        for (int i = 0; i < 6; i++)
        {
            IconScript.lampon[i] = false;
            if (i < 4) ItemTrigger.itemdefeat[i] = false;
        }
        if (type == 0) SceneManager.LoadScene("Main Menu");
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
