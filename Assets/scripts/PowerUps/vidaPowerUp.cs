using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaPowerUp : powerUpClass
{
    public vidaPowerUp()
    {
        NameP = "Mas Vida";
        Description = "Aumenta los PV +10";
    }
    public override void use(playerstats PS)
    {
        base.use(PS);
        PS.maxVida += 10;
        PS.vida += 10;
    }
}
