using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Timeline;

public class PU_BiggerHammer : PowerUp
{
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        //Debug.Log("Jump Effect");
        // var Player = GameObject.Find("player").GetComponent<PlayerController>();
        //PlayerController Player = GameObject.Find("player").GetComponent<PlayerController>();

        //gameObject.SetActive(true);

        //BiggerMelee.SetActive(true);
        //biggerMelee.SetActive(true);
        //meleeAttack.SetActive(true);



        //if (Input.GetMouseButtonDown(0))
        //{
        //    biggerM();

        //}


        //if (meleeTriggered)
        //{
        //    if (timeElapsedSinceMelee < meleeDuration)
        //    {
        //        timeElapsedSinceMelee += Time.deltaTime;
        //    }
        //    else
        //    {
        //        biggerMelee.SetActive(false);
        //        timeElapsedSinceMelee = 0;
        //        meleeTriggered = false;

        //    }

        Player.meleeAttack.SetActive(false);

        Player.biggerMelee.SetActive(true);



        //if (PU_BiggerHammer = true)
        //    {
        //    Player.meleeAttack.SetActive(false);

        //    if (timeElapsedSinceMelee < meleeDuration)
        //        {
        //            timeElapsedSinceMelee += Time.deltaTime;
        //        }
        //        else
        //        {
        //            Player.biggerMelee.SetActive(false);
        //            Player.timeElapsedSinceMelee = 0;
        //            Player.meleeTriggered = false;
        //        }
        //    }


            //    MeleeAttack()
            //{
            //    //adding an audio source:
            //    //audioSource.PlayOneShot(attackClip);

            //    meleeAttack.SetActive(true);
            //    //set inactive when given a power up
            //    meleeAttack.transform.localPosition = new Vector3(AttackOffset * facingDirection, meleeAttack.transform.localPosition.y, 0);

            //    meleeTriggered = true;

            //    //flips melee sprite
            //    meleeSR.flipX = sr.flipX;




        }


    private void MeleeAttack()
    {
       // //adding an audio source:
       // //audioSource.PlayOneShot(attackClip);

       // Player.biggerMelee.SetActive(true);
       // //set inactive when given a power up
       // Player.biggerMelee.transform.localPosition = new Vector3(AttackOffset * facingDirection, meleeAttack.transform.localPosition.y, 0);

       // Player.meleeTriggered = true;

       // //flips melee sprite
       //Player.biggerMelee.flipX = sr.flipX;

    MeleeAttack();



    }
    //Debug.Log("Larger Hammer activated");


    //}



    //}


    protected override void NegateEffect()
    {
        base.NegateEffect();
        Player.biggerMelee.SetActive(false);



    }




}
