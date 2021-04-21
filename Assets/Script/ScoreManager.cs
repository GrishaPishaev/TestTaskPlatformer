using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int Score;
    public Text ScoreDisplay;

    void Update()
    {
        ScoreDisplay.text = "Ñ÷¸ò: " + Score.ToString();
    }

    public void Kill(int AddedScores)
    {
        Score += AddedScores;
    }
}
