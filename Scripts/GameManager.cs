using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public UnityEvent OnScoreIncreased;

    private int score = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    public void IncreaseScore(int amount)
    {
        score += amount;
        Debug.Log("Score increased to:  " + score);
        OnScoreIncreased.Invoke();
    }

    public int GetScore()
    {
        return score;
    }
}
