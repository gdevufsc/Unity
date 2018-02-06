using UnityEngine;
using System.Collections;

public class projectileBehaviour : MonoBehaviour {
	public Vector2 destroyPosition = new Vector2(20,10);

	void Start(){
		this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(25,0,0);
	}

	void Update() {
		if (this.transform.position.y > destroyPosition.y || this.transform.position.x > destroyPosition.x
			|| this.transform.position.y < -destroyPosition.y || this.transform.position.x < -destroyPosition.x) {
				Destroy (this.gameObject);
		}
	}

	void OnCollisionEnter(){
		Destroy (this.gameObject);
		GameObject.FindGameObjectWithTag ("score").gameObject.SendMessage ("enemyKilled");
	}
}

public class enemyBehaviour : MonoBehaviour {
	public Vector2 destroyPosition = new Vector2(20,10);

	void Start(){
		this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-10f,0.1f,0f);
		this.gameObject.GetComponent<Rigidbody>().angularDrag = 0.005f;
	}
	
	void Update() {
		if (this.transform.position.y > destroyPosition.y || this.transform.position.x > destroyPosition.x
		    || this.transform.position.y < -destroyPosition.y || this.transform.position.x < -destroyPosition.x)
		{
			GameObject.FindGameObjectWithTag ("score").gameObject.SendMessage ("dodgedEnemy");
			Destroy(this.gameObject);
		}
	}
	
	void OnCollisionEnter(){
		Destroy (this.gameObject);
	}
}

public class powerBehaviour : MonoBehaviour {
	public Vector2 destroyPosition = new Vector2(20,10);
	
	void Start(){
		this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(-10f,0.1f,0f);
		this.gameObject.GetComponent<Rigidbody>().angularDrag = 0.005f;
	}
	
	void Update() {
		if (this.transform.position.y > destroyPosition.y || this.transform.position.x > destroyPosition.x
		    || this.transform.position.y < -destroyPosition.y || this.transform.position.x < -destroyPosition.x)
		{
			Destroy(this.gameObject);
		}
	}
	
	void OnCollisionEnter(){
		Destroy (this.gameObject);
	}
}