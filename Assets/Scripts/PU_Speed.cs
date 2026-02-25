using UnityEngine;

public class Speed : PowerUp
{
    public override void ApplyEffect()
    {
        base.ApplyEffect();
        //Debug.Log("Health Effect");
        // PlayerController = GameObject.Find("player").GetComponent<PlayerController>();
        //PlayerController Player = GameObject.Find("player").GetComponent<PlayerController>();
        Player.movementSpeed += 50;

    }

    protected override void NegateEffect()
    {
        base.NegateEffect();
        Player.movementSpeed -= 50;


    }







}
