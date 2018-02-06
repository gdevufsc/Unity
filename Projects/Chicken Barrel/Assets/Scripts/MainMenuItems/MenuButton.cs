//botao da tela de game over
//funçao: voltar para o menu principal

using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape))
		{
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
		}	
	}
	void OnMouseDown(){
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
