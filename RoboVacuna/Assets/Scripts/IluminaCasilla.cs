using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IluminaCasilla : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] float opacidad = 0.3f;
    float opacidadIni;
    Vector2 borde;
    public bool ocupada = false;

    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        opacidadIni = sprite.color.a;
        borde = GetComponent<Collider2D>().bounds.extents;
    }

    private void Update()
    {
        if (Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x + borde.x
            && Camera.main.ScreenToWorldPoint(Input.mousePosition).x > transform.position.x - borde.x
            && Camera.main.ScreenToWorldPoint(Input.mousePosition).y < transform.position.y + borde.y
            && Camera.main.ScreenToWorldPoint(Input.mousePosition).y > transform.position.y - borde.y
            && GameManager.instance.colocando && !ocupada)
        {
            sprite.color = new Color(0, 0, 0, opacidad);
        }
        else sprite.color = new Color(0, 0, 0, opacidadIni);
    }
}
