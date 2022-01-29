using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore instance;
    public Text scoreText;
    public Text higScoreText;

    int score = 0;

    private void Start()
    {
        scoreText.text = score.ToString() + "points";
        higScoreText.text = "total" + higScoreText.ToString();

    }
    void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        scoreText.text = score.ToString() + "points";
        higScoreText.text = "total" + higScoreText.ToString();
    }

    public void AddPoints(int points)
    {
        Debug.Log(score);
        score = score + points;
        if (PlayerPrefs.GetInt("higscore", score) < score)
        {
            PlayerPrefs.SetInt("higscore", score);

        }
        Debug.Log("Score: " + score);
    }
}
