using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerstats : MonoBehaviour
{
    public float vida;
    public float daño;
    public float velocidad=5;
    public float regeneracion;
    public float bulletSpeed;
    public float velocidadRecarga;
    public float shootSpeed;
    void Start()
    {
        velocidad = 5;
        bulletSpeed = 20;
        shootSpeed = 0.3f;
    }
}
