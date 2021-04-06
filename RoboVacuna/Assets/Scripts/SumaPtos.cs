using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SumaPtos : MonoBehaviour
{
    public int tiempo = 3, puntos = 1;
    void Start()
    {
        GameManager.instance.ReseteaPtos();
        InvokeRepeating("SumaPuntos", 6, tiempo);
    }

    void SumaPuntos()
    {
        GameManager.instance.SumaPtos(puntos);
    }
}
