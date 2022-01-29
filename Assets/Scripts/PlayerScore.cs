using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore instance;
    public Text scoreText;
    public Text higScoreText;
    public Text poinstText;


    int score ;

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
        Debug.Log("addPoints: " + points);
        score = score + points;

        showScore(points);
        if (PlayerPrefs.GetInt("higscore", score) < score)
        {
            PlayerPrefs.SetInt("higscore", score);

        }

    }
    public void showScore(int points)
    {
   
        if (points < 1)
        {
            Debug.Log("isPoison");
            //lose life 
            poinstText.color = Color.red;
            poinstText.text = "ouch";

        }
        else
        {
            Debug.Log("no poison");
            //sum score
            poinstText.color = Color.yellow;
            poinstText.text = "+" + points.ToString() + "pts";
        }
    }
}
