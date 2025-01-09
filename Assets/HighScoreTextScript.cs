using UnityEngine;

using UnityEngine.UI;
public class HighScoreTextScript : MonoBehaviour
{
    [SerializeField] Text highScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetFloat("HighScore").ToString();
    }
}
