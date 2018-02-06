using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour {

    // t é o objeto a ser encontrado e então instanciado
    GameObject t;
    // tInstance é a instancia gerada
    GameObject tInstance;
    //v é a velocidade do tiro;
    float v;

	void Start () {
        v = 10f;
        //encontrando objeto e colocando em t
        t = Resources.Load("Tirinho") as GameObject;
	}
	
	void Update () {
        //se tu aperta espaço
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //instancia t, armazena em tInstance, com a posição do GameObject a q está associado o script, rotação zerada
            tInstance = Instantiate(t, transform.position, Quaternion.Euler(Vector3.zero));

            //põe velocidade v na instancia tInstance
            tInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(0, v);

            //destroi a instancia depois de 2 segundos para não ficar pesando na memoria, acumulando mil tiros
            Destroy(tInstance, 2);
        }
	}

}
