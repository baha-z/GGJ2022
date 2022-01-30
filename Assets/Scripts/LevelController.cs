using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    PlayerScore scoreScript;
    Spawner spawner;
    float timer;
    float currentScore = 0;
    float lastScore = 0;

    public float timeFlag = 30;
    public float pointFlag = 10;
    public string generatorName = "Generator";

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        getPlayerScore();

        if(timer >= timeFlag || currentScore >= lastScore + pointFlag){
            lastScore = currentScore;
            timer = 0;

            handlerLevelIncrease();
        }
    }

    void getPlayerScore() {
        Camera camera = Camera.main;

        scoreScript = camera.GetComponent<PlayerScore>();

        currentScore = scoreScript.score;
    }

    void handlerLevelIncrease () {
        GameObject generator = GameObject.Find(generatorName);

        spawner = generator.GetComponent<Spawner>();

        Potions sanityScript = spawner.sanityPotion.GetComponent<Potions>();
        Potions crazyScript = spawner.crazyPotion.GetComponent<Potions>();

        if(spawner.interval > .5f){
            spawner.interval -= - .1f;
        }

        if(sanityScript.time > .5f){
            sanityScript.time -= .2f;
        }

        crazyScript.time += .2f;
    }
}
