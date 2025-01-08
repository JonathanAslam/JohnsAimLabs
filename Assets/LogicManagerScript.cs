using UnityEngine;
using UnityEngine.UI;

public class LogicManagerScript : MonoBehaviour
{
    [SerializeField] Text timerText;
    private bool isGameOver = false;
    private float timer = 30f;
    // private float highScore;

    //update timer every frame
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
        }
    }

}

