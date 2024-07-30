using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    public GameObject balaPrefab; 
    public Transform puntoDisparo; 
    private bool canShoot = true;
    playerstats stats;

    void Start()
    {
        stats = GameObject.FindWithTag("Player").GetComponent<playerstats>();
        canShoot = true;
    }

    void Update()
    {
        if (!stats.Puede) return;
        if (Input.GetMouseButton(0) && canShoot)
        {
            StartCoroutine(Disparar());
        }
    }

    IEnumerator Disparar()
    {
        canShoot = false;
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation); 
        Destroy(bala, 4f);
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        rb.velocity = puntoDisparo.right * stats.bulletSpeed;
        yield return new WaitForSecondsRealtime(stats.shootSpeed);
        canShoot = true;
    }
}
