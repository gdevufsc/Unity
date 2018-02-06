using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour {

    Rigidbody2D r;
    //v é a velocidade em metros por segundo no eixo y
    float v = -5;
    //c é um clone, a retornado pelo método instantiate
    //public Transform c;

	void Start () {
        r = GetComponent<Rigidbody2D>();
        r.velocity = new Vector2(0, v);
	}
	
	void Update () {

        //-20.48 foi a altura que percebi que o background saida da tela, daí precisa instanciar outro e destruir esse
        if(transform.position.y <= -20.4f)
        {
            Instantiate(this, new Vector3 (0,20.4f,10), Quaternion.Euler(Vector3.zero));
            Destroy(gameObject,0);
        }
	}
}
