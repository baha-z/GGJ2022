using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Potions : MonoBehaviour 
{

    public float time;
    public int points;
    public bool isPoison = false;
    public bool isRed = false;
    public bool isBlack = false;
    public AudioSource audioSource;
    public AudioClip[] clips;
    public float volume = 0.5f;
    private int index;


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
        index = Random.Range(0, clips.Length);
        audioSource.PlayOneShot(clips[index], volume);
        StartCoroutine(myWaitCoroutine());
    }

    IEnumerator myWaitCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        if(isPoison){
            points = -20;
        }
        PlayerScore.instance.AddPoints(points, isRed, isBlack);
        Destroy(gameObject);

    }

}
