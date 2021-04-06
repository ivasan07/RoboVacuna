using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SigueMouse : MonoBehaviour
{
    [SerializeField] int puntos = 30;
    [SerializeField] AudioClip audio;
    AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
            GameManager.instance.ptos += puntos;
            GameManager.instance.colocando = false;
        }
        Vector2 pos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        transform.position = pos;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetMouseButtonDown(0) && collision.gameObject.GetComponent<IluminaCasilla>()
            && !collision.gameObject.GetComponent<IluminaCasilla>().ocupada)
        {
            if (GetComponent<Generador>())
            {
                GetComponent<Generador>().ComienzaSuma();
                GetComponent<Generador>().restaPuntos = true;
            }
            source.clip = audio;
            source.Play();
            GetComponents<Collider2D>()[0].enabled = true;
            transform.position = collision.gameObject.transform.position;
            transform.SetParent(collision.gameObject.transform);
            collision.gameObject.GetComponent<IluminaCasilla>().ocupada = true;
            Destroy(this);
            GameManager.instance.colocando = false;
            if (gameObject.GetComponent<AtacaVirus>())
                gameObject.GetComponent<AtacaVirus>().enabled = true;
        }
    }
}
