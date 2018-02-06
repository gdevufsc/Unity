using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNave : MonoBehaviour {

    float v;
    Rigidbody2D r;

	void Start () {
        v = 4;
        r = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -4)
            r.velocity = new Vector2(-v, 0);
        
        else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < 4)
            r.velocity = new Vector2(v, 0);

        else
            r.velocity = new Vector2(0, 0);
	}
}
