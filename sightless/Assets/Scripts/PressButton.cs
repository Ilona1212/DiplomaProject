using UnityEngine;
using UnityEngine.SceneManagement;

public class PressButton : MonoBehaviour
{
    public int typebutton = 0;

    private void OnMouseUp()
    {
        switch(typebutton)
        {
            case 0:
            {
                SceneManager.LoadScene("Comics");
                break;
            }
            case 1:
            {
                print("Options");
                break;
            }
            case 2:
            {
                Application.Quit();
                break;
            }
        }
    }
}
