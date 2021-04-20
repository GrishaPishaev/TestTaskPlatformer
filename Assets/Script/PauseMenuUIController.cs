using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUIController : MonoBehaviour
{
    public GameObject PauseMenuUI;

    public void ShowPauseMenu()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ClosePauseMenu()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
