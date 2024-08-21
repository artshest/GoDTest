using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour, IService
{

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SetPause(bool pause)
    {
        if (pause) 
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
}
