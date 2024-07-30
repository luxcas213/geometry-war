using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class upgradeGunPowerUp : powerUpClass
{
    gunManager GM;
    public upgradeGunPowerUp()
    {
        NameP = "Upgrade Gun";
        Description = "agrega un cañon mas al arma";
    }
    public override void use(playerstats PS)
    {
        base.use(PS);
        PS.regeneracion += 1;
        GM=GameObject.FindWithTag("gunManager").GetComponent<gunManager>();
        GM.upgradeGun();
    }
}
