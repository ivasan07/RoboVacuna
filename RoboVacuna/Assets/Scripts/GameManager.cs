using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    static public GameManager instance; //instancia del GM
    public int ptos = 15;
    public bool colocando = false;

    private void Awake() //Singleton
    {
        if (instance == null) //si no hay instancia
        {
            instance = this; //la creamos
            DontDestroyOnLoad(gameObject); //evitamos que se destruya entre escenas
        }
        else //en caso contrario
        {
            Destroy(gameObject); //destruimos la instancia
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape)) SceneManager.LoadScene("Menu"); ;
    }

    public void ReseteaPtos()
    {
        ptos = 15;
    }

    public void SumaPtos(int suma)
    {
        ptos += suma;
    }

    public void ChangeScene()
    {
        if (SceneManager.GetActiveScene().name == "Main")
        {
            SceneManager.LoadScene("Menu");
        }
        else
        {
            SceneManager.LoadScene("Main");
        }
        ptos = 15;
        colocando = false;
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
