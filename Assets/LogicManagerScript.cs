using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManagerScript : MonoBehaviour
{
    [SerializeField] Text timerText;

    [SerializeField] Text highScoreText;
    
    //reference to game object, we will use the targetshooterscript object since that contains the targetshooterscript
    private TargetShooterScript targetShooterScript;
    private bool isGameOver = false;
    private float timer = 30f;

    private void Update() {
        // if game is still going, continue with decrementing counter
        if (!isGameOver) {
            timer -= Time.deltaTime;
            timerText.text = "Time: " + timer.ToString();
            if (timer <= 0) {
                isGameOver = true;
                timer = 0;
                timerText.text = "Time: 0";
            }
        } else {
            //get reference to targetshooterScript
            targetShooterScript = GameObject.FindGameObjectWithTag("Player").GetComponent<TargetShooterScript>();
            //save score to playerprefs so we can access it in the game over scene
            PlayerPrefs.SetFloat("Score", targetShooterScript.score);
            if (targetShooterScript.score > PlayerPrefs.GetFloat("HighScore")) {
                PlayerPrefs.SetFloat("HighScore", targetShooterScript.score);
                //display highscore text updated in highScoreScript
                highScoreText.text = "High Score: " + PlayerPrefs.GetFloat("HighScore").ToString();
                //save playerprefs
                PlayerPrefs.Save();
            }
            //end game logic
            // display game over screen
            SceneManager.LoadScene("GameOverScene");
                // in screen components
                    // display score, highscore
                    // button to play again and button to go to home screen
        }
    }

}

