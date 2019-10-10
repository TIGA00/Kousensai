using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript1 : MonoBehaviour {
    public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -100)
        {
            Destroy(gameObject);
        }
	}

    public void SetVelocity(Vector3 forward)
    {
        var rid = GetComponent<Rigidbody>();
        rid.velocity = transform.forward * speed;
    }
	private void OnCollisionEnter(Collision collider){
		if (collider.gameObject.tag == "Stage") {
			Destroy (gameObject);
			Debug.Log ("shotDes");
		}
	}
}
