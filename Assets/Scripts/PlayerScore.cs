using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class PlayerScore : MonoBehaviour
{
    public static PlayerScore instance;
    public Text scoreText;
    public Text higScoreText;
    public Text poinstText;
    public int life = 4;
    public GameObject Doctor;
    private int scoreMark = 0;

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

    public void LoseLife()
    {
        life--;
        UpdateScoreMark();

        Debug.Log("losing a life!" + life);

        if (life < 1)
        {
            PlayerPrefs.SetInt("score", score);
            SceneManager.LoadScene("GameOver");

        } else if (life < 3)
        {
            Doctor.GetComponent<DoctorMovement>().TransformAdvance();
        }
    }

    public void RecoverLife()
    {
        if ((score - scoreMark) >= 20)
        {
            
            if (life < 4) life++;

            UpdateScoreMark();

            if (life > 0) Doctor.GetComponent<DoctorMovement>().TransformRegression();
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
            LoseLife();

        }
        else
        {
            Debug.Log("no poison");
            //sum score
            poinstText.color = Color.yellow;
            poinstText.text = "+" + points.ToString() + "pts";

            RecoverLife();
        }
    }

    private void UpdateScoreMark()
    {
        scoreMark = score;
    }
}
