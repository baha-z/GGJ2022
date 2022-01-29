using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{

    //public Text higScoreText;
    public Text scoreText;

    private void Start()
    {
        //higScoreText.text = "highscore: " + PlayerPrefs.GetInt("highscore").ToString();
        scoreText.text = "score: " + PlayerPrefs.GetString("score").ToString();
        Debug.Log(scoreText.text);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("MainMenu");
    }

}
