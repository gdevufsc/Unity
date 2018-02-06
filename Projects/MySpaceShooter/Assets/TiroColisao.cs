using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroColisao : MonoBehaviour {

    GameObject n;
    GameObject spawnstuff;
    //GameObject explosion;
    GameObject e;

    private void Start()
    {
        n = GameObject.FindGameObjectWithTag("Pont");
        spawnstuff = GameObject.FindGameObjectWithTag("Spawner");
        //explosion = GameObject.FindGameObjectWithTag("explosion");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject, 0);
        Destroy(this.gameObject, 0);
        n.SendMessage("Somaponto");
        spawnstuff.SendMessage("AumentaDificuldade");
        e = Instantiate(Resources.Load("ExplosionNode") as GameObject, collision.transform.position, Quaternion.Euler(Vector3.zero));
        Destroy(e.gameObject, 1f);
        
    }
}
