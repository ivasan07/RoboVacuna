using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesplzCamara : MonoBehaviour
{
    bool mov = false;
    [SerializeField] float velHorizontal = 2, tiempo = 3;

    void Start()
    {
        Invoke("ComienzaMov", tiempo);
    }


    void Update()
    {
        if (mov && transform.position.x >= 0)
            transform.position = transform.position + new Vector3(-velHorizontal, 0, 0) * Time.deltaTime;
    }

    void ComienzaMov()
    {
        mov = true;
    }
}
