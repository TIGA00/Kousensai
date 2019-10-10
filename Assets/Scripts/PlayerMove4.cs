using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;
public class PlayerMove4: MonoBehaviour {
	public float speed = 15f;
	public float jumpSpeed = 8f;
	public float gra = 20f;
	private Vector3 moveDir = Vector3.zero;
	public float rotSpeed = 10f;
	// Use this for initialization
	private AnimatorStateInfo animInfo;
	private Animator anim;
	public Transform rayPos;
	public float rayRan = 0.85f;
	public bool isGround;
    private Transform mainCam;
    //for boost
    public float boostSpeed = 1.0f;
   // Rigidbody rigidBody;
    public float touchDelay = 0.5f;
    public bool isBoostF = false;
    public bool isMashF = false;
	private float boostSec = BOOST_SEC;
	public static float BOOST_SEC = 1.0f;
	void Start () {
        mainCam = transform.Find("Main Camera4");
        
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController chCon = GetComponent<CharacterController> ();
        GamepadState inSta = GamepadInput.GamePad.GetState(GamePad.Index.Four);
		Rigidbody rigidBody = GetComponent<Rigidbody>();
		//Debug.Log ("worldPosition"+transform.TransformDirection(moveDir));
		if (!chCon.isGrounded) {
			if (Physics.Linecast (rayPos.position, (rayPos.position - transform.up * rayRan))) {
				isGround = true;
			} else {
				isGround = false;
			}
		}

		if (chCon.isGrounded||isGround) {
            if (isMashF == false && isBoostF == false)
            {
			
                if(GamePad.GetButtonUp(GamePad.Button.B, GamePad.Index.Four)){
                    isMashF = true;
                }
            }else {
				if(touchDelay >= 0) {
					if (GamePad.GetButtonDown(GamePad.Button.B, GamePad.Index.Four) ){
                        //rigidBody.AddForce(Vector3.forward * boostSpeed, ForceMode.VelocityChange);
						//rigidBody.velocity += (Vector3.forward * boostSpeed) * Time.fixedDeltaTime;
						//rigidBody.velocity += transform.forward * boostSpeed;
						//chCon.Move(transform.forward * boostSpeed);
						isBoostF = true;
						//chCon.velocity += transform.forward * boostSpeed;
						Debug.Log("boost");
						isMashF = false;
						touchDelay = 0.5f;
                    }
				} else {
					isMashF = false;
					touchDelay = 0.5f;
				}
                touchDelay -= Time.deltaTime;
            }
			if(isBoostF) {
				if(boostSec >= 0) {
					chCon.Move(transform.forward * boostSpeed * Mathf.Sqrt(boostSec)*Time.deltaTime);
					boostSec -= Time.deltaTime;
				}else {
					boostSec = BOOST_SEC;
					isBoostF = false;
				}
			}
			if (inSta.B == true) {
				moveDir = new Vector3 (0, 0, 1);
			} else if (inSta.X) {
				moveDir = new Vector3 (0, 0, -1);
			} else if (inSta.X == false && inSta.B == false) {
				moveDir = new Vector3 (0, 0, 0);
			}
			moveDir = transform.TransformDirection (moveDir);
			moveDir *= speed;
			transform.Rotate (0, GamePad.GetAxis(GamePad.Axis.LeftStick,GamePad.Index.Four).x * rotSpeed, 0);
			Vector3 angles = mainCam.eulerAngles;
			if(angles.x > 180 && angles.x < 340 && GamePad.GetAxis(GamePad.Axis.LeftStick,GamePad.Index.Four).y > 0)
			{
				angles = new Vector3(340, angles.y, angles.z);
			}
			else if(angles.x <= 180 && angles.x > 20 && GamePad.GetAxis(GamePad.Axis.LeftStick,GamePad.Index.Four).y <= 0)
			{
				angles = new Vector3(20, angles.y, angles.z);
			}
			else
			{
				mainCam.eulerAngles = new Vector3(angles.x + GamePad.GetAxis(GamePad.Axis.LeftStick,GamePad.Index.Four).y * rotSpeed * -1, angles.y, angles.z);
			}
			//Debug.Log ("true");
		} else {
			//Debug.Log ("false2");
		}
		moveDir.y -= gra * Time.deltaTime;
		chCon.Move (moveDir*Time.deltaTime);
	}
		/*if(inSta.X == true){
			Debug.Log ("X");
		}else{
			Debug.Log("IsNotX");
		}*/

		/*moveDir.y -= gra * Time.deltaTime;
		chCon.Move (moveDir*Time.deltaTime);*/

}
