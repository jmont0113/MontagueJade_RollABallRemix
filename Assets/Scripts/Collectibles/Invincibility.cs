using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerUpBase
{
    protected override void PowerupDuration(Player player)
    {
        Player _player = player.GetComponent<Player>();

        if (_player != null)
        {
            player.changeColor();

            DelayHelper.DelayAction(this, player.returnColor, 3.0f);

            base.PowerupDuration(player);
        }
    }
}
