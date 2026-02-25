using UnityEngine;

public class Jump : PowerUp
{
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        //Debug.Log("Jump Effect");
        // var Player = GameObject.Find("player").GetComponent<PlayerController>();
        //PlayerController Player = GameObject.Find("player").GetComponent<PlayerController>();
        Player.jumpSpeed += 4;


    }


    protected override void NegateEffect()
    {
        base.NegateEffect();
        Player.jumpSpeed -= 4;


    }







}
