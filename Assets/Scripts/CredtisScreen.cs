using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CredtisScreen : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SceneManager.LoadScene("MainMenu");
    }
}
