using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtacaVirus2 : MonoBehaviour
{
    Animator anim;
    public int vidaRobot = 100;
    public int danyo = 30;
    bool primerAtaque = false;
    int index = 0;
    int index2 = 0;
    GameObject[] viruses; GameObject[] viruses2;
    public AudioClip chorro, martillo;
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        viruses = new GameObject[1000];
        viruses2 = new GameObject[1000];
    }

    void Update()
    {
        if (vidaRobot <= 0)
        {
            transform.parent.GetComponent<IluminaCasilla>().ocupada = false;
            Destroy(this.gameObject);
        }

        int j = 0;
        int k = 0;
        while (j < index && viruses[j] == null) j++;
        if (j >= index && primerAtaque && !gameObject.GetComponent<Robot3>())
        {
            anim.SetBool("Dispara2", false);
            source.Stop();
            GetComponents<Collider2D>()[0].enabled = true;
            GetComponents<Collider2D>()[1].enabled = false;
        }
        if (!GetComponent<Robot2>())
        {
            while (k < index2 && viruses2[k] == null) k++;
            if (k >= index2 && primerAtaque)
            {
                anim.SetBool("Dispara3", false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("virus") && !gameObject.GetComponent<Robot3>())
        {
            viruses[index] = collision.gameObject;
            index++;
            GetComponents<Collider2D>()[0].enabled = false;
            GetComponents<Collider2D>()[1].enabled = true;
            anim.SetBool("Dispara2", true);
            primerAtaque = true;
        }
        else if (collision.gameObject.CompareTag("virus"))
        {
            viruses2[index2] = collision.gameObject;
            index2++;
            anim.SetBool("Dispara3", true);
            primerAtaque = true;
        }
    }

    public void Ataca()
    {
        if (!gameObject.GetComponent<Robot3>())
        {
            source.clip = chorro;
            source.Play();
            for (int i = 0; i < index; i++)
                if (viruses[i] != null) viruses[i].GetComponent<AtacaRobot>().vidaVirus -= danyo;
        }
        else
        {
            source.clip = martillo;
            source.Play();
            int i = 0;
            while (viruses2[i] == null) i++;
            viruses2[i].GetComponent<AtacaRobot>().vidaVirus -= danyo;
        }
    }
}
