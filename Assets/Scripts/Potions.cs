using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Potions : MonoBehaviour
{

    public int time;
    public int points;
    public Text textfield;

    // Update is called once per frame
    void Update()
    {
        Lifespan();
    }

    private void Lifespan()
    {
        // Kills the game object in 5 seconds after loading the object
        Destroy(gameObject,time);
    }


    void OnMouseDown()
    {
        var rend = GetComponent<Renderer>();
        rend.enabled = false;
        Destroy(gameObject, 0.5f);

        textfield.text = "+" + points.ToString() + "pts";
    }
}
