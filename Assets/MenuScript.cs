using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void Play()
    { 
        SceneManager.LoadScene("Stage1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
