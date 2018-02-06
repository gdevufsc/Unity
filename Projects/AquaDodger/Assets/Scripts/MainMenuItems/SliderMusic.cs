using UnityEngine;
using System.Collections;

public class SliderMusic : MonoBehaviour {

	public float hSliderValue = 0.0F;
	public float xPos, yPos;

	void OnGUI() {
		hSliderValue = GUI.HorizontalSlider(
			new Rect(Screen.width*xPos / 100, Screen.height*yPos / 100, 100, 30),
			hSliderValue, 0.0F, 10.0F);
	}

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
	}
}
