using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunManager : MonoBehaviour
{
    playerstats stats;
    public GameObject balaPrefab;
    public GameObject GunHolder;
    public int cantArmas;
    void Start()
    {
        cantArmas = 0;
        Cursor.visible = false;
        stats = GameObject.FindWithTag("Player").GetComponent<playerstats>();
        upgradeGun();
        
    }
    void Update()
    {
        if (!stats.Puede) return;
        GirarHaciaElMouse();
    }

    void GirarHaciaElMouse()
    {
        
        Vector3 posicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        
        Vector3 direccion = posicionMouse - transform.position;
        direccion.z = 0; 

        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angulo));
    }
    public void upgradeGun()
    {
        cantArmas++;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        

        float k = 360f / cantArmas;
        float act = 0;

        for (int i = 0; i < cantArmas; i++)
        {
            Quaternion rotation = Quaternion.Euler(this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y, this.transform.rotation.eulerAngles.z + act);
            GameObject gun = Instantiate(GunHolder, this.transform.position, rotation);
            gun.transform.SetParent(this.transform);
            gun.GetComponentInChildren<disparo>().balaPrefab = balaPrefab;
            act += k;
        }
    }
}
