using UnityEngine;
using UnityEngine.UI;

public class ClickButtonMove : MonoBehaviour
{
    public Transform ball;
    public GameObject player;
    public Rigidbody2D rb;
    private int run = 0;
    private Animator anim;

    void Start()
    {
        anim = player.GetComponent<Animator>();
        rb = player.GetComponent<Rigidbody2D>();
    }
    /*void OnMouseDown()
    {
        print("Click");
    }*/
    void OnMouseDrag()
    {
        if (PauseMenu.pause == false)
        {
            //HealthPoint.SetHealth(0.001f, false);
            Vector3 mouse = Input.mousePosition;//
            print(mouse.x);
            //Vector3 mouse = Input.GetTouch(0).position;
            ///target_vector = mouse - transform.position; // new Vector3(mouse.x - 132f, mouse.y - 120f, 0);
            if (Input.GetMouseButton(0))
            {
                if (transform.position.magnitude < 100)
                {
                    //ball.uvRect = new Rect((mouse.x - 158f)/10f, (mouse.y - 137f)/10, 1f, 1f);
                    ball.transform.localPosition = mouse - GetPosMouse.centerpos;
                    if (ball.transform.localPosition.x > 2f) run = 1;
                    else if (ball.transform.localPosition.x < -2f) run = -1;
                    else run = 0;
                }
            }
            else
            {
                //ball.uvRect = new Rect(0f, 0f, 1f, 1f);
                ball.transform.localPosition = new Vector2(2f, 2f);
                run = 0;
            }
            /*if (mouse.x - 132f < 120f && mouse.x - 132f > -120f && mouse.y - 120f < 120f && mouse.y - 120f > -120f)
            {
                if (mouse.x - 132f < 80f && mouse.x - 132f > -80f && mouse.y - 120f < 80f && mouse.y - 120f > -80f) ball.transform.localPosition = new Vector3(mouse.x - 132f, mouse.y - 120f, 0);
                else
                {
                    if (mouse.x - 132f > 40f) ball.transform.localPosition = new Vector3(40f, ball.transform.localPosition.y, 0);
                    else if (mouse.x - 132f < -40f) ball.transform.localPosition = new Vector3(-40f, ball.transform.localPosition.y, 0);
                    else if (mouse.y - 120f > 40f) ball.transform.localPosition = new Vector3(ball.transform.localPosition.x, 40f, 0);
                    else if (mouse.y - 120f < -40f) ball.transform.localPosition = new Vector3(ball.transform.localPosition.x, -40f, 0);
                }
                if (ball.transform.localPosition.x > 2f) run = 1;
                else if (ball.transform.localPosition.x < -2f) run = -1;
                else run = 0;
            }*/
        }
    }
    void OnMouseUp()
    {
        //ball.uvRect = new Rect(0f, 0f, 1f, 1f);
        ball.transform.localPosition = new Vector2(2f, 2f);
        run = 0;
    }
    private void FixedUpdate()
    {
        if (run != 0 && EnemyFunction.buttonforwon == 4)
        {
            player.transform.localScale = new Vector3(run == -1 ? (-0.4f) : (0.4f), 0.4f, 1f);
            //rb.MovePosition(rb.position + Vector2.right * run * MovePlayer.speed * Time.deltaTime);
            //rb.velocity = new Vector2(MovePlayer.speed, rb.velocity.y);
            player.transform.position -= -player.transform.right * run * MovePlayer.speed * Time.deltaTime;
            if (UseButton.fuel > 0f) anim.SetBool("IsMovingLamp", true);
            else anim.SetBool("IsMoving", true);
        }
        else
        {
            anim.SetBool("IsMoving", false);
            anim.SetBool("IsMovingLamp", false);
        }
    }
}