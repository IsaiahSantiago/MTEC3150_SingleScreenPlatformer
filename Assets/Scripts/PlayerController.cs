using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float movementSpeed;
    public float jumpSpeed;
    private float xMove;
    private Rigidbody2D rb;
    private float xVelocity;
    private bool jumpFlag = false;

    public LayerMask ground;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");

        // transform.Translate(xMove * movementSpeed * Time.deltaTime, 0, 0);
        //float xVelocity = xMove * movementSpeed * Time.deltaTime;

                if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            jumpFlag = true;

        }


    }

    private void FixedUpdate()
    {
        //rb.linearVelocity = new Vector3 (xVelocity, rb.linearVelocityY, 0);
        xVelocity = xMove * movementSpeed * Time.deltaTime;
        rb.linearVelocity = new Vector3(xVelocity, rb.linearVelocity.y, 0);

        if (jumpFlag)  //!false vs blank False is IF NOT false or IS false
        {
            rb.linearVelocityY = jumpSpeed;
            jumpFlag = false;


        }

    }
        private bool IsGrounded()
    {
        float radius = GetComponent<Collider2D>().bounds.extents.x;
        float dist = GetComponent<Collider2D>().bounds.extents.y;

        return Physics2D.CircleCast(transform.position, radius, Vector2.down, dist,ground);




    }








    }














