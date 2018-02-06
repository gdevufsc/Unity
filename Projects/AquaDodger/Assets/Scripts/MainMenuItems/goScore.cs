using UnityEngine;
using System.Collections;

public class goScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("lastScore")) {
			this.GetComponent<TextMesh>().text = "Score: " + PlayerPrefs.GetInt("lastScore").ToString();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
