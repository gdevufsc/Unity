using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PontuationScript : MonoBehaviour {

    public int points;
    Text t;

	void Start () {
        points = 0;
        t = GetComponent<Text>();
	}
	
	void Update () {
        t.text = points.ToString();
	}

    //Somaponto é chamada a partir de TiroColisão, porque se pontua quando colide o tiro com o asteroide
    public void Somaponto ()
    {
        points += 1;
    }
}
