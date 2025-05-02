using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpTime = 0.3f;
    public float jumpHeight = 2f;
    public Rigidbody2D rb;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI LivesText;

    public GameObject GameOverUI;
    public TextMeshProUGUI GameOverScoreText;
    public TextMeshProUGUI GameOverHighScoreText;
    public Button RestartButton;
    public Button MainMenuButton;

    public int lives = 3;
    private int score = 0;
    private bool isGameOver = false;

    void Start()
    {
        UpdateUI();
        GameOverUI.SetActive(false);

        RestartButton.onClick.AddListener(RestartGame);
        MainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    void Update()
    {
        if (isGameOver) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 origin = rb.position;
            Vector2 target = origin + new Vector2(0, jumpHeight);
            Vector2 velocity = CalculateProjectileVelocity(origin, target, jumpTime);
            rb.velocity = velocity;
        }

        UpdateUI();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGameOver) return;

        if (collision.collider.CompareTag("Obstacle"))
        {
            lives--;
            Destroy(collision.gameObject);

            if (lives <= 0)
            {
                GameOver();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Score"))
        {
            score++;
            Destroy(other.gameObject);
        }
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;

        rb.simulated = false;
        GameOverUI.SetActive(true);

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        GameOverScoreText.text = "Score: " + score;
        GameOverHighScoreText.text = "High Score: " + highScore;

        Time.timeScale = 0f;
        Destroy(gameObject); // ????????????
    }

    void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distance = target - origin;
        float velocityX = distance.x / time;
        float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;
        return new Vector2(velocityX, velocityY);
    }

    void UpdateUI()
    {
        ScoreText.text = "Score: " + score;
        if (LivesText != null)
        {
            LivesText.text = "Lives: " + lives;
        }
    }
}
