using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public int danyo = 100;
    AudioSource source;
    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<AtacaRobot>())
        {
            collision.GetComponent<AtacaRobot>().vidaVirus -= danyo;
        }
        if (!collision.gameObject.CompareTag("casilla") && !collision.gameObject.CompareTag("robot"))
        {
            source.Play();
            Invoke("Rompe", source.clip.length - 0.3f);
        }
    }

    public void Rompe()
    {
        Destroy(this.gameObject);
    }
}
