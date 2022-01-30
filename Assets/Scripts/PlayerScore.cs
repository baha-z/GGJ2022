using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
public class PlayerScore : MonoBehaviour
{
    public static PlayerScore instance;
    public Text scoreText;
    public Text poinstText;
    public int life = 4;
    public GameObject Doctor;
    private int scoreMark = 0;
    private int PointsToRecoverLife = 20;

    // Text timing
    private float TextTimer = 1f;
    private float DissapearingTime;

    public int score ;
    int highScore;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore");
        scoreText.text = score.ToString() + "points";
    }
    void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        scoreText.text = score.ToString() + "points";

        if (Time.time > DissapearingTime) poinstText.text = "";
    }

    public void AddPoints(int points)
    {
        score = score + points;
        showScore(points);
       
    }

    public void LoseLife()
    {
        life--;
        UpdateScoreMark();

        Debug.Log("losing a life!" + life);

        if (life < 1)
        {
            PlayerPrefs.SetInt("score", score);
            saveHighScore();
            GetComponent<AudioController>().EndMusic();
            SceneManager.LoadScene("GameOver");

        } else if (life < 3)
        {
            Doctor.GetComponent<DoctorMovement>().TransformAdvance();
            GetComponent<AudioController>().UpdateTrack();
        }
    }

    public void RecoverLife()
    {
        if ((score - scoreMark) >= PointsToRecoverLife)
        {
            
            if (life < 4) life++;

            UpdateScoreMark();

            if (life > 0)
            {
                Doctor.GetComponent<DoctorMovement>().TransformRegression();
                GetComponent<AudioController>().UpdateTrack();
            }
        }
    }

    public void showScore(int points)
    {
   
        if (points < 1)
        {
            //lose life 
            poinstText.color = Color.red;
            poinstText.text = "ouch";
            LoseLife();

        }
        else
        {
            //sum score
            poinstText.color = Color.yellow;
            poinstText.text = "+" + points.ToString() + "pts";

            RecoverLife();
        }
        DissapearingTime = Time.time + TextTimer;
    }

    private void UpdateScoreMark()
    {
        scoreMark = score;
    }

    private void saveHighScore()
    {
        Debug.Log("saveHighScore:  " + score);

        if (highScore < score)
        {
            Debug.Log("new highScore:  " + score);
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
