using UnityEngine;

public class FallingDown : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MovePlayer.Death();
    }
}
