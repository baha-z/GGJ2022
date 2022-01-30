using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Script Objects
    PlayerScore scoreScript;
    Spawner spawner;
    // Current time
    float timer;
    // Current score
    float currentScore = 0;
    // Last score saved
    float lastScore = 0;

    // Time in seconds to trigger every change
    public float timeFlag = 60;
    // Quantity of points to trigger every change
    public float pointFlag = 100;
    // Name of generator object
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

    // Method to get score from main camera script
    void getPlayerScore() {
        Camera camera = Camera.main;

        scoreScript = camera.GetComponent<PlayerScore>();

        currentScore = scoreScript.score;
    }

    // Method to overwrite to generator script and potion scripts the new values
    void handlerLevelIncrease () {
        GameObject generator = GameObject.Find(generatorName);

        spawner = generator.GetComponent<Spawner>();

        Potions sanityScript = spawner.sanityPotion.GetComponent<Potions>();
        Potions crazyScript = spawner.crazyPotion.GetComponent<Potions>();

        if(spawner.interval > .5f){
            spawner.interval -= - .1f;
        }

        if(sanityScript.time > .3f){
            sanityScript.time -= .2f;
        }

        crazyScript.time += .2f;
    }
}
