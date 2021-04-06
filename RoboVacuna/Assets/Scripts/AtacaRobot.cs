using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtacaRobot : MonoBehaviour
{
    public int vidaVirus = 100000;
    public int danyo = 100;
    GameObject robot = null;

    private void Update()
    {
        bool camina = true;
        if (vidaVirus <= 0)
        {
            Destroy(gameObject);
        }
        if (robot == null || robot.GetComponents<Collider2D>()[0].enabled == false && camina) GetComponent<MovHorizontal>().velHorizontal = -0.5f;
        if ((robot != null && robot.GetComponent<AtacaVirus2>() && transform.position.x <= robot.transform.position.x + 1.65f) || (robot != null && robot.GetComponent<AtacaVirus>() && transform.position.x <= robot.transform.position.x + 1.65f))
        {
            GetComponent<MovHorizontal>().velHorizontal = 0;
            camina = false;
        }
        else camina = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (!collision.gameObject.GetComponents<Collider2D>()[0].enabled && (!collision.gameObject.GetComponent<Robot3>() || !collision.gameObject.GetComponent<Generador>()))
            if (collision.gameObject.GetComponent<AtacaVirus>() || collision.gameObject.GetComponent<AtacaVirus2>() || collision.gameObject.GetComponent<Generador>())
            {
                GetComponent<MovHorizontal>().velHorizontal = 0;
                robot = collision.gameObject;
                InvokeRepeating("Ataque", 0, 3);
            }
        if (collision.gameObject.GetComponent<Robot3>() || collision.gameObject.GetComponent<Generador>())
        {
            GetComponent<MovHorizontal>().velHorizontal = 0;
            robot = collision.gameObject;
            InvokeRepeating("Ataque", 0, 3);
        }
    }

    public void Ataque()
    {
        if (robot != null && !robot.GetComponent<Robot3>())
        {
            if (robot.GetComponent<AtacaVirus>()) robot.GetComponent<AtacaVirus>().vidaRobot -= danyo;
            else if (robot.GetComponent<AtacaVirus2>()) robot.GetComponent<AtacaVirus2>().vidaRobot -= danyo;
            else if (robot.GetComponent<Generador>()) robot.GetComponent<Generador>().vidaGen -= danyo;
        }
        else if (robot != null && robot.GetComponent<Robot3>())
        {
            robot.GetComponent<AtacaVirus2>().vidaRobot -= danyo;
        }
    }
}
