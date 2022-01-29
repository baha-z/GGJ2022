using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject sanityPotion;
    public GameObject crazyPotion;
    float tiempo;
    public float intervalo;
    public float range;

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;

        if(tiempo >= intervalo) {
            generate();
            tiempo = 0;
        }
        
    }

    void generate() {
        float randomX = Random.Range(-range, range);
        float randomY = Random.Range(-range, range);
        bool isSanityPotion = Random.value > .5;
        Vector3 position = this.transform.position;

        position.x = position.x + randomX;
        position.y = position.y + randomY;

        if(isSanityPotion){
            Instantiate(sanityPotion, position, Quaternion.identity);
        } else {
            Instantiate(crazyPotion, position, Quaternion.identity);
        }
    }
}
