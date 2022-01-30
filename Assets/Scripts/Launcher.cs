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
    float force = 10000f;

    void Start () {
        // Load force to init launcher movement
        rb2d = GetComponent<Rigidbody2D>();
        Vector2 impulse = new Vector2(force, 0);
        rb2d.AddForce(impulse);

        // Try to prepare potion with fall velocity and force
        Rigidbody2D potionRb2d = sanityPotion.GetComponent<Rigidbody2D>();
        potionRb2d.velocity = new Vector2(0, -force);
        Vector2 impulseY = new Vector2(0, -force);
        potionRb2d.AddForce(impulseY);
    }

    void Update() {
        HandleMove();
        time += Time.deltaTime;

        if(time >= interval) {
            launch();

            time = 0;
        }
    }

    // Handle horizontal move
    void HandleMove() {
        Camera camera = Camera.main;
        float camHeight = camera.orthographicSize / 2f;
        float camWidth = camera.aspect * camHeight - 50f;

        if(this.transform.position.x > 0){
            if(this.transform.position.x > camWidth){
                Vector2 impulse = new Vector2(-1000f, 0);
                rb2d.AddForce(impulse);    
            }
        }else {
            if(this.transform.position.x < -camWidth){
                Vector2 impulse = new Vector2(1000f, 0);
                rb2d.AddForce(impulse);        
            }
        }
        
    }

    // Shoot potions
    void launch() {
        Instantiate(sanityPotion, this.transform.position, Quaternion.identity);
    }
}
