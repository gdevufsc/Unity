using UnityEngine;
using System.Collections;

public class RecordsButton : MonoBehaviour {

	bool onMainMenu = true;
	public Vector3 originalPos, targetPos;
	public float smoothTime = 0.3F;
	private Vector3 velocity = Vector3.zero;
	GameObject mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
	}

	// Update is called once per frame
	void Update () {
		if(onMainMenu){
			mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, originalPos, ref velocity, smoothTime);
		}
		else {
			mainCamera.transform.position = Vector3.SmoothDamp(mainCamera.transform.position, targetPos, ref velocity, smoothTime);
		}
		
		if (Input.GetKey(KeyCode.Escape))
		{
			if(onMainMenu){
				Application.Quit();
			}
			else{
				returnToMainMenu();
			}
		}
	}

	void OnMouseDown(){
		onMainMenu = false;
	}

	void returnToMainMenu(){
		onMainMenu = true;
	}
}
