using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dañoPowerUp : powerUpClass
{
    public dañoPowerUp() 
    {
        NameP = "mas Daño";
        Description = "aumento de 10p de daño";
        
    }
    public override void use(playerstats PS)
    {
        base.use(PS);
        PS.daño += 10;
    }
}
