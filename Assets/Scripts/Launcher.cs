using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    Rigidbody2D rb2d;
    // Game objects to generate
    public GameObject[] Potions;
    // Time controller
    float     time;
    // Interval between every generation on seconds
    public float interval;
    // Value to generate force
    public float force = 30000f;

    GameObject pota;

    void Start () {
  
        pota = Potions[Random.Range(0, Potions.Length)];
        Rigidbody2D potionRb2d = pota.GetComponent<Rigidbody2D>();
        Vector2 impulseY = new Vector2(0, -force);
        potionRb2d.AddForce(impulseY);
    }

    void Update() {
        time += Time.deltaTime;

        if(time >= interval) {
            launch();

            time = 0;
        }
    }

    // Shoot potions
    void launch() {
         Instantiate(pota, this.transform.position, Quaternion.identity);
    }
}
