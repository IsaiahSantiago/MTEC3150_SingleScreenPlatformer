using UnityEngine;

public class PowerUp : MonoBehaviour
{

    protected SpriteRenderer sr;
    public Color powerUpColor;
    protected PlayerController Player;

    private bool effectsApplied = false;
    public float effectDuration;
    public float timeElapsedSinceEffect; 

    private void Start()
    {

        Player = GameObject.Find("Player").GetComponent<PlayerController>();
        sr = GetComponent<SpriteRenderer>();
        sr.color = powerUpColor;


    }

    public virtual void ApplyEffect()
    {

        //Debug.Log("Needs to apply effects");
        //Destroy(gameObject);
        sr.enabled = false; //turns sprite off
        effectsApplied = true;
        GetComponent<Collider2D>().enabled = false;


    }

    private void Update()
    {
        if (effectsApplied)
        {
            if(timeElapsedSinceEffect < effectDuration)
            {
                timeElapsedSinceEffect += Time.deltaTime;
            }
            else
            {
                timeElapsedSinceEffect = 0;
                NegateEffect();
                effectsApplied = false;
                Destroy(gameObject);

            }
        }
    }


    protected virtual void NegateEffect()
    {
        //effectsApplied = false;

    }


    //apply a timer in the update in order to revert the effectss of the power up on the player and disable the srptie.

}


