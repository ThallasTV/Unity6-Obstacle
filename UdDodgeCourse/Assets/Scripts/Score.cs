using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private float gameTime;
    [SerializeField] private float scoreIncrementLevel = 1f;
    [SerializeField] private TextMeshProUGUI scoreText; // Reference to the TextMesh component for displaying score
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        score = 0; // Initialize score to 0
        gameTime = 0; // Initialize game time to 0
        UpdateScoreText(); // Update the score text in the UI
    }
    // Update is called once per frame
    void Update()
    {
        ScoreUpdate(); // Call the ScoreUpdate method to handle score updates
    }

    void ScoreUpdate()
    {
        gameTime += Time.deltaTime; // Increment game time by the time since the last frame
        if(gameTime >= scoreIncrementLevel)
        {
            score += 1; // Increment score by 1 every 5 seconds
            gameTime = 0; // Reset game time
            UpdateScoreText(); // Update the score text in the UI
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Object"))
        {
            score -= 5; // Increment score by 1 when colliding with the player
            UpdateScoreText();
            
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // Update the score text in the UI
    }
}
