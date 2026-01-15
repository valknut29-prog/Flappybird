using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] Text scoreText;
    private bool isGameOver = false;
    public int score = 0;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    public void AddScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    
    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        Debug.Log("GAME OVER");
        Time.timeScale = 0f;
    }
}