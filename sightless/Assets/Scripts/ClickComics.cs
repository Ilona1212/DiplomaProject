using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickComics : MonoBehaviour
{
    public GameObject[] comics;
    private int full = 0;

    void OnMouseDown()
    {
        if(++full < 5)
        {
            comics[full-1].SetActive(true);
        }
        else SceneManager.LoadScene("Level 1");
    }
}
