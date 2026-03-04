using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Timeline;

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
    public GameObject meleeAttack;
    public GameObject biggerMelee;

    private float facingDirection;
    
    public float AttackOffset = 1.1f;

    public float meleeDuration = 0.25f;
    private float timeElapsedSinceMelee = 0f;

    private bool meleeTriggered = false;

    public GameObject bulletPrefab;

    public float bulletSpeed = 200;
    private float defaultBulletSpeed;
    public Color bulletColor = Color.yellow;
    private Color defaultBulletColor;

    private SpriteRenderer sr;
    private SpriteRenderer meleeSR;
    public SpriteRenderer biggerM;

    private Animator anim;

    public AudioClip jumpClip, attackClip, landingClip;

    private AudioSource audioSource; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingDirection = 1;
        defaultBulletSpeed = bulletSpeed;
        defaultBulletColor = bulletColor;

        sr = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
        meleeSR = meleeAttack.GetComponent<SpriteRenderer>();
        biggerM = biggerMelee.GetComponent<SpriteRenderer>();


        audioSource = GetComponentInChildren<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        xMove = Input.GetAxisRaw("Horizontal");

        // transform.Translate(xMove * movementSpeed * Time.deltaTime, 0, 0);
        //float xVelocity = xMove * movementSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            audioSource.PlayOneShot(jumpClip);

            jumpFlag = true;
              anim.SetTrigger("Jump");
            jumpFlag = true;

        }

        if (Input.GetMouseButtonDown(0))
        {
            MeleeAttack();

        }

        if (Input.GetMouseButtonDown(1))
        {
            RangedAttack();

        }

        if (xMove != 0)
        {
            facingDirection = xMove;

            anim.SetBool("Walking", true); //Referencing the animator when moving to transition from idle to walking animation.


            //spriteRenderer.flipX 
            //Move Player X orientation:
            /* Remember that before the line above we have:
            private float facingDirection;
            facingDirection = 1;
            */

            //if (facingDirection == 0)
            //{
            //    gameObject.transform.localScale = new Vector3(1, 1, 1);
            //}
            //else 
            //{
            //    gameObject.transform.localScale = new Vector3(-1, -1, -1);
            //}

            //sr.flipX = facingDirection > 0 ? true : false;

            if (facingDirection > 0)
            {
                sr.flipX = false;
            }
            else
            {
                sr.flipX = true;
            }
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        

        if (meleeTriggered)
        {
            if (timeElapsedSinceMelee < meleeDuration)
            {
                timeElapsedSinceMelee += Time.deltaTime;
            }
            else 
            {
                meleeAttack.SetActive(false);
                timeElapsedSinceMelee = 0;
                meleeTriggered = false;

            }

        
        }



        WhenOnPlatform();

        //Debug.Log("Player on platform is :" + IsOnPlatform());
        //Debug.Log(IsGrounded());
        //transform.Translate(xMove * movementSpeed * Time.deltaTime, 0, 0); 



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

    private void MeleeAttack() 
    {
        //adding an audio source:
        audioSource.PlayOneShot(attackClip);

        meleeAttack.SetActive(true);
        //set inactive when given a power up
        meleeAttack.transform.localPosition = new Vector3(AttackOffset * facingDirection, meleeAttack.transform.localPosition.y, 0);

        meleeTriggered = true;

        //flips melee sprite
        meleeSR.flipX = sr.flipX;




    }



    private void RangedAttack() 
    {
        Vector3 pos = new Vector3(transform.position.x + (AttackOffset * facingDirection), transform.position.y, 0);
        GameObject bullet = Instantiate(bulletPrefab, pos, Quaternion.identity);
        //bullet.GetComponent<Bullet>().Direction = new Vector2(facingDirection, 0);
        Bullet bScript = bullet.GetComponent<Bullet>();

        bScript.direction = new Vector2(facingDirection, 0);
        bScript.col = bulletColor;
        bScript.speed = bulletSpeed;





    }
    private void OnLanding()
    {
        anim.SetTrigger("Landed");
        audioSource.PlayOneShot(landingClip);
    }


    private bool IsGrounded()
    {
        float radius = GetComponent<Collider2D>().bounds.extents.x;
        float dist = GetComponent<Collider2D>().bounds.extents.y;

        return Physics2D.CircleCast(transform.position, radius, Vector2.down, dist,ground);



    }


    private void  WhenOnPlatform()
    {
        if (IsGrounded())
        {
            float radius = GetComponent<Collider2D>().bounds.extents.x;
            float dist = GetComponent<Collider2D>().bounds.extents.y;

            RaycastHit2D hit;
            hit = Physics2D.CircleCast(transform.position, radius, Vector2.down, dist, ground);


            if (hit.transform.gameObject.CompareTag("Platform"))
            {
                transform.SetParent(hit.transform);

            }

         else
            {
                transform.SetParent(null);
            }
        }
        else
        {
            transform.SetParent(null);
        }

    
    }




    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PowerUp>() != null) 
        {
        collision.GetComponent<PowerUp>().ApplyEffect();
        
        }
        

    }

      public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnLanding();   
        }
    }


    public void ApplybulletChanges(float speed, Color color)
    {
        bulletSpeed = speed;
        bulletColor = color;
    }

    public void ResetBullet()
    {
        ApplybulletChanges(defaultBulletSpeed, defaultBulletColor);
    
    }






}














