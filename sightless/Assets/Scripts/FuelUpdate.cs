using UnityEngine;
using UnityEngine.UI;

public class FuelUpdate : MonoBehaviour
{
    //public Image filling;
    void FixedUpdate()
    {
        if (UseButton.fuel > 0f && !PauseMenu.pause && ItemTrigger.founditem < 4)
        {
            UseButton.SetFuel(0.001f, false);
            GetComponent<Image>().fillAmount = UseButton.fuel;
        }
    }
}
