using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    Rigidbody2D rb2d;
    // Game objects to generate
    public GameObject sanityPotion;
    // Time controller
    float time;
    // Interval between every generation on seconds
    public float interval;
    // Value to generate force
    public float force = 30000f;

    void Start () {
        Rigidbody2D potionRb2d = sanityPotion.GetComponent<Rigidbody2D>();
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
        Instantiate(sanityPotion, this.transform.position, Quaternion.identity);
    }
}
