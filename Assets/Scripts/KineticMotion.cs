using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticMotion : MonoBehaviour
{
    public float cycleWitdh;
    public float frequency;
    float cX;
    float counter;
    float xSen;
    // Start is called before the first frame update
    void Start() {
        cX = this.transform.position.x;
    }

    // Update is called once per frame
    void Update() {
        counter = counter + (frequency/100);
        xSen = Mathf.Sin(counter);

        this.transform.position = new Vector3(cX+(xSen*cycleWitdh), this.transform.position.y, 0);
        if(counter > 6.28f) {
            counter = 0;
        }
    }
}
