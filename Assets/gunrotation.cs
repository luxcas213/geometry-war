using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunrotation : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
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
}
