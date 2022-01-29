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
    // Items random to create
    public float creationRange = 1;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time >= interval) {
            for(int i = 0; i < Random.Range(1, creationRange); i++) {
                generate();
            }
            time = 0;
        }
        
    }

    // Method to generate random object arround father position 
    void generate() {
        float randomX = Random.Range(-range, range);
        float randomY = Random.Range(-range/2, range/2);
        bool isSanityPotion = Random.value > .5;
        Vector3 position = this.transform.position;

        position.x = position.x + randomX;
        position.y = position.y + randomY;

        // Doctor sprite reference position
        GameObject doctor = GameObject.Find("Doctor");
        Collider2D doctorCollider = doctor.GetComponent<Collider2D>();
        float doctorX = doctorCollider.bounds.extents.x;
        float doctorY = doctorCollider.bounds.extents.y;

        if((position.x <= doctorX && position.x >= -doctorX) && (position.y <= doctorY && position.y >= -doctorY)){
            generate();
            return;
        }
        
        Camera camera = Camera.main;
        float halfHeight = camera.orthographicSize / 2f;
        float halfWidth = camera.aspect * halfHeight;

        if(position.x >= halfWidth || position.y >= halfHeight ){
            generate();
            return;
        }

        if(isSanityPotion){
            Instantiate(sanityPotion, position, Quaternion.identity);
        } else {
            Instantiate(crazyPotion, position, Quaternion.identity);
        }
    }
}
