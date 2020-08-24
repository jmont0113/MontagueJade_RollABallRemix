using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncer : Enemy
{
    [SerializeField] float bounceAmount = 300f;

    protected override void PlayerImpact(Player player)
    {
        Rigidbody playerRigibody = player.GetComponent<Rigidbody>();

        if (player != null)
        {
            // get the player's velocity and invert it
            Vector3 bounceDirection = -playerRigibody.velocity;
            // apply this force
            playerRigibody.AddForce(bounceDirection * bounceAmount);
            //need the enemy base
            base.PlayerImpact(player);
        }
    }
}
