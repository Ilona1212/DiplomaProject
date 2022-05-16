using UnityEngine;

public class MoveLight : MonoBehaviour
{
    public Transform player;

    void Start()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    void FixedUpdate()
    {
        //Vector3 target = new Vector3(player.position.x, player.position.y, transform.position.z);
        //Vector3 currentPosition = Vector3.Lerp(transform.position, target, Time.deltaTime);
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}

