using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript1 : MonoBehaviour {
    public float speed = 1.0f;
	private float Ctime = 1.0f ;
	private float inval = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y < -100||inval>Ctime)
        {
            Destroy(gameObject);
			inval = 0;
			Debug.Log ("shotDes2");
        }
		inval += Time.deltaTime;
	}

    public void SetVelocity(Vector3 forward)
    {
        var rid = GetComponent<Rigidbody>();
        rid.velocity = transform.forward * speed;
    }
	private void OnCollisionEnter(Collision collider){
		if (collider.gameObject.tag == "Stage"||collider.gameObject.tag == "P1"||collider.gameObject.tag == "P2"||collider.gameObject.tag == "P3"||collider.gameObject.tag == "P4") {
			Destroy (gameObject);
			Debug.Log ("shotDes");
		}
	}
}
