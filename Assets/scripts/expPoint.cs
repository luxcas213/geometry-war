using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expPoint : MonoBehaviour
{
    public int xpValue; 
    playerstats stats;
    void Start()
    {
        xpValue = Random.Range(1, 11);
        float scaleValue = Mathf.Lerp(0.3f, 0.7f, xpValue / 10f);
        transform.localScale = Vector3.one * scaleValue;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<playerstats>().GanarExperiencia(xpValue);
            Destroy(this.gameObject);
        }
    }
}
