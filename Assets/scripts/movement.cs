using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 mov;
    playerstats stats;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        stats = GameObject.FindWithTag("Player").GetComponent<playerstats>();
    }
    void Update()
    {
        if (!stats.Puede) return;
        mov.x = Input.GetAxisRaw("Horizontal");
        mov.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + mov.normalized * stats.velocidad * Time.fixedDeltaTime);
    }
}
