using UnityEngine;
using System.Collections;

public class ButtonDefaut : MonoBehaviour {

	public Color colorDefault, colorSelected;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter(){
		GetComponent<Renderer>().material.color = colorSelected;
	}

	void OnMouseExit(){
		GetComponent<Renderer>().material.color = colorDefault;
	}
}
