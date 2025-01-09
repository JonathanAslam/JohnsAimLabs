using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [SerializeField] Text finalScoreText;
    [SerializeField] Text highScoreText;
    // private TargetShooterScript targetShooterScript;

    public void Start() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        //get reference to targetshooterScript for the score variable
        // targetShooterScript = GameObject.FindGameObjectWithTag("Player").GetComponent<TargetShooterScript>();
        //display score
        finalScoreText.text = "Score: " + PlayerPrefs.GetFloat("Score").ToString();
        Debug.Log("Score: " + PlayerPrefs.GetFloat("Score").ToString());
        //display highscore
        highScoreText.text = "High Score: " + PlayerPrefs.GetFloat("HighScore").ToString();

    }
    // Play Again Button
    public void RestartGame() {
        SceneManager.LoadScene("GameScene");
    }
    // Return to Main Menu Button
    public void ReturnToMainMenu() {
        SceneManager.LoadScene("MenuScene");
    }
}
