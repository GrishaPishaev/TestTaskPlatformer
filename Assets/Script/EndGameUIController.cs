using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGameUIController : MonoBehaviour
{
    public GameObject EndGameMenuUI;
    public Text TextForEndGame;

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

    public void ShowEndgGameMenu(string Text)
    {
        EndGameMenuUI.SetActive(true);
        Time.timeScale = 0f;
        TextForEndGame.text = Text;
    }

}
