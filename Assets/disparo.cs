using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    public GameObject balaPrefab; 
    public Transform puntoDisparo; 
    public float velocidadBala = 20f;
    private bool canShoot=true;
    playerstats stats;
    void Start()
    {
        stats = GameObject.FindWithTag("Player").GetComponent<playerstats>();
        canShoot = true;
    }
    void Update()
    {
        if (Input.GetMouseButton(0) && canShoot) StartCoroutine(Disparar());
    }

    IEnumerator Disparar()
    {
        canShoot = false;
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation); 
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        rb.velocity = puntoDisparo.right * stats.bulletSpeed;
        yield return new WaitForSecondsRealtime(stats.shootSpeed);
        canShoot = true;
    }
    
    
}
