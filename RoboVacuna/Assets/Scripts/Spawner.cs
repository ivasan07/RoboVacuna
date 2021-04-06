using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject virus1, virus2, virus3;
    void Start()
    {
        Invoke("GenerateEnemy", Random.Range(60, 90));
    }

    public void GenerateEnemy()
    {
        int rnd = Random.Range(0, 100);

        if (rnd >= 85) Instantiate(virus3, transform.position, Quaternion.identity);
        else if (rnd >= 50) Instantiate(virus2, transform.position, Quaternion.identity);
        else Instantiate(virus1, transform.position, Quaternion.identity);

        Invoke("GenerateEnemy", Random.Range(40, 55));
    }
}
