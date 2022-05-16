using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public float damping = 5f;
    public Vector2 offset = new Vector2(0f, 2f);
    public bool faceLeft;
    public Transform player;
    private int lastX;

    void Start()
    {
        //offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer();
    }

    public void FindPlayer()
    {
        transform.position = new Vector3(0.94f - offset.x, player.position.y + 4f + offset.y, transform.position.z);
    }

    void FixedUpdate()
    {
        int currentX = Mathf.RoundToInt(player.position.x);
        faceLeft = currentX > lastX ? false:true; 
        lastX = Mathf.RoundToInt(player.position.x);
        Vector3 target;
        if (player.position.x < 0.9996768f) target = new Vector3(0.94f - offset.x, player.position.y + 4f + offset.y, transform.position.z);
        else 
        {
            if (EnemyFunction.buttonforwon != 4) offset.y = Random.Range(-2.5f, -1.5f);
            else offset.y = -2f;
            if (faceLeft) target = new Vector3(player.position.x - offset.x, player.position.y + 4f + offset.y, transform.position.z);
            else target = new Vector3(player.position.x + offset.x, player.position.y + 4f + offset.y, transform.position.z);
        }
        Vector3 currentPosition = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
        transform.position = currentPosition;
    }
}
