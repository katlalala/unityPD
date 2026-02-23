using UnityEngine;
using TMPro;

public class DonutCount : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int _score = 0;

    public void AddScore(int amount)
    {
        _score += amount;
        if (scoreText != null)
        {
            scoreText.text = "Score: " + _score;
        }
    }

    public void StartGame()
    {
        _score = 0;
        AddScore(0);
    }
}