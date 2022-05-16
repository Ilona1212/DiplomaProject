using UnityEngine;

public class MenuRotate : MonoBehaviour
{
    private float rotateZ = 0f;
    public bool left = false;

    void Update()
    {
        if(left == false)
        {
            rotateZ += 0.15f;
            if (rotateZ > 360) rotateZ = 0f;
        }
        else
        {
            rotateZ -= 0.15f;
            if (rotateZ < 0) rotateZ = 360f;
        }
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rotateZ);
    }
}
