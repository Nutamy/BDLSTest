using UnityEngine;
using TMPro;

public class UpdateUI : MonoBehaviour
{
    public TMP_Text scoreText;

    private void Start()
    {
        GameManager.instance.OnScoreIncreased.AddListener(UpdateScore);
        Debug.Log("ScoreDisplay subscribed to OnScoreIncreased");
        UpdateScore();
    }

    private void UpdateScore()
    {
        string currentScore = GameManager.instance.GetScore().ToString();
        scoreText.text = "Score: " + currentScore;
    }
}
