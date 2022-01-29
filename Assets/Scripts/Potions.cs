using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Potions : MonoBehaviour
{

    public int time;
    public int points;
    public bool isPoison;
    public AudioSource audioSource;
    public AudioClip clip;
    public float volume = 0.5f;

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
        audioSource.PlayOneShot(clip, volume);
        StartCoroutine(myWaitCoroutine());
    }

    IEnumerator myWaitCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        PlayerScore.instance.AddPoints(points);
        Destroy(gameObject);

    }

}
