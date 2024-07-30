using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class regenerationPowerUp : powerUpClass
{
    public regenerationPowerUp()
    {
        NameP = "Regeneration";
        Description = "aumento en la regeneracion de PV +1";
    }
    public override void use(playerstats PS)
    {
        base.use(PS);
        PS.regeneracion += 1;
    }
}
