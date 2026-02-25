using UnityEngine;

public class PU_Agility : PowerUp
{
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        //Debug.Log("Jump Effect");
        // var Player = GameObject.Find("player").GetComponent<PlayerController>();
        //PlayerController Player = GameObject.Find("player").GetComponent<PlayerController>();
        Player.jumpSpeed += 4;
        Player.movementSpeed += 100;

    }


    protected override void NegateEffect()
    {
        Player.jumpSpeed -= 4;
        Player.movementSpeed -= 100;

        //Player.jumpSpeed = Player.jumpSpeed - 4;
        //Player.movementSpeed = Player.movementSpeed - 100;


        Debug.Log("Hello World");


    }






}


