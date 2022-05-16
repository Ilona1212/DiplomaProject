using UnityEngine;

public class GetPosMouse : MonoBehaviour
{
    public static Vector3 centerpos;
    public GameObject box;
    private void OnMouseDown()
    {
        box.GetComponent<BoxCollider>().enabled = true;
        centerpos = Input.mousePosition;
        this.gameObject.SetActive(false);
    }
}
