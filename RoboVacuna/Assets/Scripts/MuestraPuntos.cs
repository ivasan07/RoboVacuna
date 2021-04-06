using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuestraPuntos : MonoBehaviour
{
    void Update()
    {
        GetComponent<Text>().text = GameManager.instance.ptos.ToString();
    }
}
