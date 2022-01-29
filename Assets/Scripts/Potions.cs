using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Potions : MonoBehaviour
{

    public int time;
    public int points;
    public bool isPoison;
    public Text textfield;

    void Start()
    {
        Lifespan();
    }

    private void Lifespan()
    {
        Destroy(gameObject,time);
    }

    void OnMouseDown()
    {
        var rend = GetComponent<Renderer>();
        rend.enabled = false;

        if (isPoison)
        {
            //lose life 
            textfield.color = Color.red;
            textfield.text = "ouch";
            StartCoroutine(myWaitCoroutine());
        }
        else
        {
            //sum score
            textfield.color = Color.yellow;
            textfield.text = "+" + points.ToString() + "pts";
            StartCoroutine(myWaitCoroutine());
        }
    }

    IEnumerator myWaitCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        textfield.text = "";
        Destroy(gameObject);
    }

}
