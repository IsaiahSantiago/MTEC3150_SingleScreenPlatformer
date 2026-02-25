using UnityEngine;

public class PU_Bullet : PowerUp 
{


    public Color bulletColor;
    //public float bulletSpeed;
    public float speedValue;

    public override void ApplyEffect()
    {
        base.ApplyEffect();
        Player.ApplybulletChanges(speedValue, bulletColor);

    
    }


    protected override void NegateEffect()
    {
        base.NegateEffect();
        Player.ResetBullet();




    }







}





