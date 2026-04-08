using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private int lives = 3;
    [SerializeField] private int score = 0;

    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private bool isGameOver = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateUI();
        Debug.Log($"Lives: {lives} | Score: {score}");
    }

    public void AddScore(int amount)
    {
        if (isGameOver) return;

        score += amount;
        UpdateUI();
    }

    public void LoseLife(int amount)
    {
        if (isGameOver) return;

        lives = Mathf.Max(lives - amount, 0);
        UpdateUI();

        if (lives == 0)
        {
            isGameOver = true;
            Debug.Log("Game Over");
        }
    }

    private void UpdateUI()
    {
        livesText.text = $"Lives: {lives}";
        scoreText.text = $"Score: {score}";
    }
}