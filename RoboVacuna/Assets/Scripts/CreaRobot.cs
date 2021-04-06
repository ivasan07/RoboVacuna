using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaRobot : MonoBehaviour
{
    [SerializeField] GameObject robot;
    public int puntos = 0;

    private void OnMouseDown()
    {
        if (GameManager.instance.ptos >= puntos && !GameManager.instance.colocando)
        {
            Instantiate(robot, transform.position, Quaternion.identity);
            GameManager.instance.ptos -= puntos;
            GameManager.instance.colocando = true;
        }
    }
}
