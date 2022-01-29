using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Game objects to generate
    public GameObject sanityPotion;
    public GameObject crazyPotion;
    // Time controller
    float time;
    // Interval between every generation on seconds
    public float interval;
    // Range of dispersion between object on units
    public float range;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= interval) {
            generate();
            time = 0;
        }
        
    }

    // Method to generate random object arround father position 
    void generate() {
        float randomX = Random.Range(-range, range);
        float randomY = Random.Range(-range, range);
        bool isSanityPotion = Random.value > .5;
        Vector3 position = this.transform.position;

        position.x = position.x + randomX;
        position.y = position.y + randomY;
        
        Camera camera = Camera.main;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;

        if(position.x >= halfWidth){
            position.x = halfWidth - 1f;
        }

        if(position.y >= halfHeight){
            position.y = halfHeight - 1f;
        }

        if(isSanityPotion){
            Instantiate(sanityPotion, position, Quaternion.identity);
        } else {
            Instantiate(crazyPotion, position, Quaternion.identity);
        }
    }
}
