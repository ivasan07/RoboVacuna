using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovHorizontal : MonoBehaviour
{
    private Vector2 posOri;
    public float vertical = 0.75f, velVertical = 3, velHorizontal = 1;

    void Start()
    {
        posOri = transform.position;
    }

    void Update()
    {
        transform.position = transform.position + new Vector3(velHorizontal, Mathf.Sin(Time.time * velVertical) * vertical, 0) * Time.deltaTime;
    }
}
