using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathzone : MonoBehaviour
{
    [SerializeField] GameObject canvas = null;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("virus") || collision.gameObject.CompareTag("bala"))
        {
            Time.timeScale = 0;
            canvas.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("virus") || collision.gameObject.CompareTag("bala"))
        {
            Time.timeScale = 0;
            canvas.SetActive(true);
        }
    }
}
