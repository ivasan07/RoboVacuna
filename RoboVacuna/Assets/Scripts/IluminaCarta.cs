using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IluminaCarta : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] float opacidad = 0.3f;
    Color colorIni;
    int puntos;

    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        colorIni = sprite.color;
        puntos = GetComponent<CreaRobot>().puntos;
    }

    private void Update()
    {
        if (GameManager.instance.ptos >= puntos) sprite.color = new Color(colorIni.r, colorIni.g, colorIni.b, opacidad);
        else sprite.color = colorIni;
    }
}
