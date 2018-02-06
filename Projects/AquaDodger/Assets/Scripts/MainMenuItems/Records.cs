using UnityEngine;
using System.Collections;

public class Records : MonoBehaviour {

	void clearScore(){
		PlayerPrefs.SetInt ("score1", 0);
		PlayerPrefs.SetInt ("score2", 0);
		PlayerPrefs.SetInt ("score3", 0);
		PlayerPrefs.SetInt ("score4", 0);
		PlayerPrefs.SetInt ("score5", 0);
	}

	void loadScore(){
		//clearScore ();
		
		if (PlayerPrefs.HasKey ("score1")) {
			GameObject.FindGameObjectWithTag ("record1").GetComponent<TextMesh> ().text
				= PlayerPrefs.GetInt ("score1").ToString ();
		}
		else{
			PlayerPrefs.SetInt ("score1",0);
			GameObject.FindGameObjectWithTag ("record1").GetComponent<TextMesh> ().text = "0";
		}
		
		if (PlayerPrefs.HasKey ("score2")) {
			GameObject.FindGameObjectWithTag ("record2").GetComponent<TextMesh> ().text
				= PlayerPrefs.GetInt("score2").ToString();
		}
		else{
			PlayerPrefs.SetInt ("score2",0);
			GameObject.FindGameObjectWithTag ("record2").GetComponent<TextMesh> ().text = "0";
		}
		
		if (PlayerPrefs.HasKey ("score3")) {
			GameObject.FindGameObjectWithTag ("record3").GetComponent<TextMesh> ().text
				= PlayerPrefs.GetInt("score3").ToString();
		}
		else{
			PlayerPrefs.SetInt ("score3",0);
			GameObject.FindGameObjectWithTag ("record3").GetComponent<TextMesh> ().text = "0";
		}
		
		if (PlayerPrefs.HasKey ("score4")) {
			GameObject.FindGameObjectWithTag ("record4").GetComponent<TextMesh> ().text
				= PlayerPrefs.GetInt("score4").ToString();
		}
		else{
			PlayerPrefs.SetInt ("score4",0);
			GameObject.FindGameObjectWithTag ("record4").GetComponent<TextMesh> ().text = "0";
		}
		
		if (PlayerPrefs.HasKey ("score5")) {
			GameObject.FindGameObjectWithTag ("record5").GetComponent<TextMesh> ().text
				= PlayerPrefs.GetInt("score5").ToString();
		}
		else{
			PlayerPrefs.SetInt ("score5",0);
			GameObject.FindGameObjectWithTag ("record5").GetComponent<TextMesh> ().text = "0";
		}
	}

	void OnLevelWasLoaded(int level) {
		if(level == 0){
			loadScore();
		}
	}

	// Use this for initialization
	void Start() {
		loadScore();
	}
}
