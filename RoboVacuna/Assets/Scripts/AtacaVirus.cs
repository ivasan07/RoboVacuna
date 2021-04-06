using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtacaVirus : MonoBehaviour
{
    [SerializeField] GameObject ammo = null;
    Vector2 pos;
    Animator anim;
    public int vidaRobot = 100;
    [SerializeField] AudioClip audio = null;
    GameObject[] viruses = new GameObject[1000]; int index = 0;
    bool primerAtaque = false;

    void Start()
    {
        pos = new Vector2(transform.position.x + 1f, transform.position.y);
    }


    private void Update()
    {
        int j = 0;
        while (j < index && viruses[j] == null) j++;
        if (j >= index && primerAtaque && !gameObject.GetComponent<Robot3>())
        {
            anim.SetBool("Dispara", false);
            GetComponents<Collider2D>()[0].enabled = true;
            GetComponents<Collider2D>()[1].enabled = false;
        }

        if (vidaRobot <= 0)
        {
            transform.parent.GetComponent<IluminaCasilla>().ocupada = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        anim = GetComponent<Animator>();
        if (collision.gameObject.CompareTag("virus"))
        {
            viruses[index] = collision.gameObject;
            index++;
            GetComponents<Collider2D>()[0].enabled = false;
            GetComponents<Collider2D>()[1].enabled = true;
            anim.SetBool("Dispara", true);
            primerAtaque = true;
        }
    }

    public void Dispara()
    {
        GetComponent<AudioSource>().clip = audio;
        GetComponent<AudioSource>().Play();
        if (ammo != null)
            Instantiate(ammo, pos, Quaternion.identity);
    }
}
