using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class Motion2 : MonoBehaviour {
    
    public float TIME = 0.2f;
    private float intime = 0;
	private Animator ani;
    public Transform gun;
    public GameObject bomb;
    public Transform Camera;
    //private AudioSource[] audioSources;

	// Use this for initialization
	void Start () {
        //audioSources = gameObject.GetComponents<AudioSource>();
        ani = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		GamepadState inSta = GamepadInput.GamePad.GetState(GamePad.Index.One);
		//if (inSta.B == true) {
        if (inSta.Y == true) {
            ani.SetInteger("Vertical", -1);
            
		//if (inSta.X == true) {
        } else if ( inSta.X == true) {    
            
            ani.SetInteger("Vertical", 1);
        } else {
            ani.SetInteger("Vertical", 0);
        }
    
        if (Input.GetButton("Button2"))
        {
            if(intime>TIME){
                GameObject newBomb = Instantiate(bomb,gun.transform.position, Camera.transform.rotation);
                newBomb.GetComponent<BombScript1>().SetVelocity(transform.forward);
                intime = 0;
            }
          //  audioSources[0].Play();
        }
        intime += Time.deltaTime;
	}
}
