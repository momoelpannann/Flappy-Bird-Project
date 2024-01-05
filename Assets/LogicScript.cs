using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    public AudioSource point;

    public void SaveHighScore()
    {
        // Get the currently saved high score
        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        // If the current score is higher than the saved high score, update it
        if (playerScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore",playerScore);
            PlayerPrefs.Save(); // Don't forget to save the changes
        }
    }
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    [ContextMenu("Increase Score")]
 

   public void DisplayHighScore()
    {
        int highScore = GetHighScore();
        // Update your high score UI element here
        highScoreText.text = "Highscore: " + highScore.ToString();
    }
    public void addScore(int score)
    {
        playerScore = playerScore + score;
        scoreText.text = playerScore.ToString();
        point.Play();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void exitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif


    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    
}
 }
