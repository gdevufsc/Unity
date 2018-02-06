//Objeto: player
/*
 * limiteInferior = -2
 * limiteSuperior = 5
 * 
*/

using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float playerSpeed;

	/// <summary>
	/// Posicao de criacao dos projeteis, equivale a posicao do personagem principal
	/// </summary>
	Vector3 spawnPosition;

	/// <summary>
	/// power-up variables
	/// </summary>
	enum playerSprite {armed, disarmed, firing};
	int bullets = 0;
	float speedTime = 0, timePowerScale = 2;

	/// <summary>
	/// position of the touch 
	/// </summary>
	private Vector3 _guiPosition;

	public float reloadTime;
	float timer = 0;

	public int vidas;
	public float limiteInferior;
	public float limiteSuperior;

	public GameObject goPrefab;

	public AudioClip audioJetpack;

	// Use this for initialization
	void Start () {
		if(vidas == 1){
			GameObject.FindGameObjectWithTag ("vidas").GetComponent<GUIText>().text = vidas.ToString()+" life";
		}
		else{
			GameObject.FindGameObjectWithTag ("vidas").GetComponent<GUIText>().text = vidas.ToString()+" lives";
		}
	}
	
	// Update is called once per frame
	void Update () {
		spawnPosition = this.gameObject.transform.position;

		timer+= Time.deltaTime;

		if(speedTime > 0){ //power-up ativo
			GameObject.FindGameObjectWithTag ("activePower").GetComponent<GUIText>().text = "time: "+(speedTime*timePowerScale).ToString();
			speedTime -= Time.deltaTime;

			if(speedTime <= 0){ //fim do power-up
				Time.timeScale = 1f;
				if(bullets > 0){
					GameObject.FindGameObjectWithTag ("activePower").GetComponent<GUIText>().text = "ammo: "+bullets.ToString();
				}
				else{
					GameObject.FindGameObjectWithTag ("activePower").GetComponent<GUIText>().text = "NOPE";
				}
			}
		}

		if (this.gameObject.transform.position.y < limiteInferior){
			//float aux = this.gameObject.transform.position.x;
			//this.gameObject.transform.position = new Vector3(aux,limiteInferior + 0.2f,0);
			this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,playerSpeed/5,0);
		}

		if (this.gameObject.transform.position.y > limiteSuperior){
			float aux = this.gameObject.transform.position.x;
			this.gameObject.transform.position = new Vector3(aux,limiteSuperior - 0.001f,0);
			this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,-playerSpeed/5,0);
		}

		//int touchCount = 0;
		foreach (Touch touch in Input.touches){

			if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled){
				//GameObject.FindGameObjectWithTag("score").GetComponent<GUIText>().text = touch.position.ToString();

				//grande botao esquerdo
				if(touch.position.x < 950 && touch.position.y < 800){
					this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,playerSpeed,0);
					GetComponent<AudioSource>().PlayOneShot(audioJetpack);
				}

				//grande botao direito
				else if(touch.position.x > 950 && touch.position.y < 800){
					if (timer >= reloadTime) {
						GameMaster gm = GameObject.FindGameObjectWithTag("score").GetComponent<GameMaster>();
						bool isPaused = gm.getPaused();
						if(bullets > 0 && !isPaused) {
							setSprite((int)playerSprite.firing);
							GameObject clone = (GameObject)Instantiate (goPrefab, spawnPosition, Quaternion.identity);
							clone.AddComponent(typeof(projectileBehaviour));
							bullets--;

							if(bullets > 0){
								GameObject.FindGameObjectWithTag ("activePower").GetComponent<GUIText>().text = "ammo: "+bullets.ToString();
							}
							else{
								GameObject.FindGameObjectWithTag ("activePower").GetComponent<GUIText>().text = "NOPE";
							}

							if(bullets == 0){
								setSprite((int)playerSprite.disarmed);
								if(speedTime > 0){
									GameObject.FindGameObjectWithTag ("activePower").GetComponent<GUIText>().text = "time: "+(speedTime*timePowerScale).ToString();
								}
								else{
									GameObject.FindGameObjectWithTag ("activePower").GetComponent<GUIText>().text = "NOPE";
								}
							}
						}
						else{
							setSprite((int)playerSprite.disarmed);
						}
						timer = 0;
					}
				}
			}
		}
	}

	void ordenaRecordes(int score){
		int aux;
		int s1 = PlayerPrefs.GetInt ("score1");
		int s2 = PlayerPrefs.GetInt ("score2");
		int s3 = PlayerPrefs.GetInt ("score3");
		int s4 = PlayerPrefs.GetInt ("score4");
		int s5 = PlayerPrefs.GetInt ("score5");

		if (score > s5) {
			s5 = score;

			if (s5 > s4){
				aux = s4;
				s4 = s5;
				s5 = aux;

				if (s4 > s3){
					aux = s3;
					s3 = s4;
					s4 = aux;

					if (s3 > s2){
						aux = s2;
						s2 = s3;
						s3 = aux;

						if (s2 > s1){
							aux = s1;
							s1 = s2;
							s2 = aux;
						}
					}
				}
			}
		}

		PlayerPrefs.SetInt ("score1",s1);
		PlayerPrefs.SetInt ("score2",s2);
		PlayerPrefs.SetInt ("score3",s3);
		PlayerPrefs.SetInt ("score4",s4);
		PlayerPrefs.SetInt ("score5",s5);
		PlayerPrefs.Save();
	}

	void OnCollisionEnter(Collision col){
		if ( col.gameObject.name == "enemy"){
			if(vidas <= 1){
				Time.timeScale = 1f;
				GameMaster gm = GameObject.FindGameObjectWithTag("score").GetComponent<GameMaster>();
				int score = gm.getScore();
				PlayerPrefs.SetInt("lastScore",score);
				ordenaRecordes(score);
				Application.LoadLevel(2);
			}
			else{
				vidas--;
				if(vidas == 1){
					GameObject.FindGameObjectWithTag ("vidas").GetComponent<GUIText>().text = vidas.ToString()+" life";
				}
				else{
					GameObject.FindGameObjectWithTag ("vidas").GetComponent<GUIText>().text = vidas.ToString()+" lives";
				}
			}
		}
		else if( col.gameObject.name == "gunPower" ){
			getPowerGun();
		}
		else if( col.gameObject.name == "timePower" ){
			getPowerTime();
		}
	}

	void getPowerGun(){
		bullets = 10;
		GameObject.FindGameObjectWithTag ("activePower").GetComponent<GUIText>().text = "ammo: "+bullets.ToString();
		setSprite ((int)playerSprite.armed);
	}

	void getPowerTime(){
		speedTime = 10;
		GameObject.FindGameObjectWithTag ("activePower").GetComponent<GUIText>().text = "time: "+(speedTime*timePowerScale).ToString();
		Time.timeScale = 1f / timePowerScale;
	}

	void setSprite(int spriteCase){
		switch (spriteCase){
			case (int)playerSprite.armed:
				GameObject.FindGameObjectWithTag ("spriteArmed").GetComponent<SpriteRenderer>().enabled = true;
				GameObject.FindGameObjectWithTag ("spriteDisarmed").GetComponent<SpriteRenderer>().enabled = false;
				GameObject.FindGameObjectWithTag ("spriteFiring").GetComponent<SpriteRenderer>().enabled = false;
			break;

			case (int)playerSprite.disarmed:
				GameObject.FindGameObjectWithTag ("spriteArmed").GetComponent<SpriteRenderer>().enabled = false;
				GameObject.FindGameObjectWithTag ("spriteDisarmed").GetComponent<SpriteRenderer>().enabled = true;
				GameObject.FindGameObjectWithTag ("spriteFiring").GetComponent<SpriteRenderer>().enabled = false;
			break;

			case (int)playerSprite.firing:
				GameObject.FindGameObjectWithTag ("spriteArmed").GetComponent<SpriteRenderer>().enabled = false;
				GameObject.FindGameObjectWithTag ("spriteDisarmed").GetComponent<SpriteRenderer>().enabled = false;
				GameObject.FindGameObjectWithTag ("spriteFiring").GetComponent<SpriteRenderer>().enabled = true;
			break;
		}
	}
}