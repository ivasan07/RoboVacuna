using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject bloqueado1, bloqueado2;
    public GameObject ayuda, creditos;
    public Button boton;

    public void VeAyuda()
    {
        boton.enabled = false;
        bloqueado1.SetActive(false);
        bloqueado2.SetActive(false);
        gameObject.SetActive(false);
        ayuda.SetActive(true);
    }
    public void VeCreditos()
    {
        boton.enabled = false;
        bloqueado1.SetActive(false);
        bloqueado2.SetActive(false);
        gameObject.SetActive(false);
        creditos.SetActive(true);
    }

    public void Reinicia()
    {
        SceneManager.LoadScene("Menu");
    }
}
