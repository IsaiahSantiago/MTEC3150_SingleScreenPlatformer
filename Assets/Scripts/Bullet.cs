using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10;
    public Vector2 direction;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public Color col;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>(); //Searches for first instance Collects the childed SpriteRenderer. Fix any issues with an array or check.


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void FixedUpdate()
    {
        rb.linearVelocity = direction * speed * Time.deltaTime;




    }








}
