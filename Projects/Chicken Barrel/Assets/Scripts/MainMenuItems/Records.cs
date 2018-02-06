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
    
    void ordenaRecordes(int score)
    {
        int aux;
        int s1 = PlayerPrefs.GetInt("score1");
        int s2 = PlayerPrefs.GetInt("score2");
        int s3 = PlayerPrefs.GetInt("score3");
        int s4 = PlayerPrefs.GetInt("score4");
        int s5 = PlayerPrefs.GetInt("score5");

        if (score > s5)
        {
            s5 = score;

            if (s5 > s4)
            {
                aux = s4;
                s4 = s5;
                s5 = aux;

                if (s4 > s3)
                {
                    aux = s3;
                    s3 = s4;
                    s4 = aux;

                    if (s3 > s2)
                    {
                        aux = s2;
                        s2 = s3;
                        s3 = aux;

                        if (s2 > s1)
                        {
                            aux = s1;
                            s1 = s2;
                            s2 = aux;
                        }
                    }
                }
            }
        }

        PlayerPrefs.SetInt("score1", s1);
        PlayerPrefs.SetInt("score2", s2);
        PlayerPrefs.SetInt("score3", s3);
        PlayerPrefs.SetInt("score4", s4);
        PlayerPrefs.SetInt("score5", s5);
        PlayerPrefs.Save();
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
