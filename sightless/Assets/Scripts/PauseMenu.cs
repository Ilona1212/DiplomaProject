using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    static public bool pause = false;
    public int typebutton = 0;
    public GameObject menu;

    // Update is called once per frame
    void OnMouseDown()
    {
        switch(typebutton)
        {
            case 0:
            {
                if (!pause)
                {
                    Time.timeScale = 0;
                    pause = true;
                    menu.SetActive(true);
                }
                else
                {
                    Time.timeScale = 1;
                    pause = false;
                    menu.SetActive(false);
                }
                break;
            }
            case 1:
            {
                Time.timeScale = 1;
                pause = false;
                menu.SetActive(false);
                break;
            }
            case 2:
            {
                Time.timeScale = 1;
                pause = false;
                menu.SetActive(false);
                SceneManager.LoadScene("Main Menu");
                break;
            }
        }
        
        //Time.timeScale = pause = pause == 1 ? 0 : 1;
    }
}
