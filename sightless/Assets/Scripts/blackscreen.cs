using UnityEngine;
using UnityEngine.UI;

public class blackscreen : MonoBehaviour
{
    public float blackcolor = 0f;
    static public int blackgo = 0; // 0 - выкл / 1 - затемнение / 2 - осветление
    public GameObject lightactive;

    private void Update()
    {
        if (blackgo == 1)
        {
            if (blackcolor < 0.95f)
            {
                blackcolor += 0.05f;
                GetComponent<Image>().color = new Color(0, 0, 0, blackcolor);
            }
            else blackgo = 0;
        }
        else if (blackgo == 2)
        {
            if (blackcolor >= 0.06f)
            {
                blackcolor -= 0.05f;
                GetComponent<Image>().color = new Color(0, 0, 0, blackcolor);
            }
            else blackgo = 0;
        }
    }
}
