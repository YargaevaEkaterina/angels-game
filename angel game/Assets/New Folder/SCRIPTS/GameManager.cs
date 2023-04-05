using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject obj;
    public Text win; 


    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnTriggerEnter(Collider obj)
    {
        Debug.Log("Exit");
        win.enabled = true;
        Invoke("EXIT",3F);
    }

    void EXIT()
    {
        Application.Quit();
    }
}
