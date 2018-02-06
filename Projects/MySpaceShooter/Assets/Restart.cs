using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
    Scene s;

    void Start () {
        s = SceneManager.GetActiveScene();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(s.buildIndex);
        }
        else if (Input.GetKey(KeyCode.M))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
