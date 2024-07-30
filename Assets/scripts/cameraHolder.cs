using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraHolder : MonoBehaviour
{
    Transform target; 

    

    void LateUpdate()
    {
        target=GameObject.FindWithTag("Player").GetComponent<Transform>();
        if (target != null)
        {
            transform.position = target.position;
        }
    }
}
