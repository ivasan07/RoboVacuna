using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public int vidaGen = 100;
    GameObject contador;
    public bool restaPuntos = false;

    private void Start()
    {
        contador = GameObject.FindGameObjectWithTag("CONTADOR");
    }

    private void Update()
    {
        if (vidaGen <= 0) Destroy(gameObject);
    }

    private void OnDestroy()
    {
        if (contador != null && restaPuntos)
        {
            contador.GetComponent<SumaPtos>().puntos -= 1;
            transform.parent.GetComponent<IluminaCasilla>().ocupada = false;
        }
    }

    public void ComienzaSuma()
    {
        contador.GetComponent<SumaPtos>().puntos += 1;
    }
}
