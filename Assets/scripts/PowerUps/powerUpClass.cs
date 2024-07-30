using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpClass : MonoBehaviour
{
    public string NameP;
    public string Description;
    public Sprite icon;
    public virtual void use(playerstats PS)
    { 
        Debug.Log("se uso" + NameP);
    }
}
