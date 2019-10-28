using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class PlayerMove1 : MonoBehaviour {
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
	void Start () {
        mainCam = transform.Find("Main Camera1");
	}
	
	// Update is called once per frame
	void Update () {
		GamepadState inSta = GamepadInput.GamePad.GetState(GamePad.Index.One);
		CharacterController chCon = GetComponent<CharacterController> ();

		//Debug.Log ("worldPosition"+transform.TransformDirection(moveDir));
		if (!chCon.isGrounded) {
			if (Physics.Linecast (rayPos.position, (rayPos.position - transform.up * rayRan))) {
				isGround = true;
				//Debug.Log ("Debug");
			} else {
				isGround = false;
			}
		}
		if (chCon.isGrounded||isGround) {
			//if (inSta.B == true) {
			if (Input.GetKey(KeyCode.W) == true) {
				moveDir = new Vector3 (0, 0, 1);
			} else if (inSta.X) {	
				moveDir = new Vector3 (0, 0, -1);
			} else if (inSta.X == false && inSta.B == false) {
			//} else if (KeyCode.W == false && KeyCode.S == false) {
				moveDir = new Vector3 (0, 0, 0);
			}
			moveDir = transform.TransformDirection (moveDir);
			moveDir *= speed;
			transform.Rotate (0, GamePad.GetAxis(GamePad.Axis.LeftStick,GamePad.Index.One).x * rotSpeed, 0);
			Vector3 angles = mainCam.eulerAngles;
			if(angles.x > 180 && angles.x < 340 && GamePad.GetAxis(GamePad.Axis.LeftStick,GamePad.Index.One).y > 0)
			{
				angles = new Vector3(340, angles.y, angles.z);
			}
			else if(angles.x <= 180 && angles.x > 20 && GamePad.GetAxis(GamePad.Axis.LeftStick,GamePad.Index.One).y <= 0)
			{
				angles = new Vector3(20, angles.y, angles.z);
			}
			else
			{
				mainCam.eulerAngles = new Vector3(angles.x + GamePad.GetAxis(GamePad.Axis.LeftStick,GamePad.Index.One).y * rotSpeed * -1, angles.y, angles.z);
			}
				
			moveDir.y -= gra * Time.deltaTime;
			
			/*
			transform.Rotate (0, Input.GetAxis ("Horizontal") * rotSpeed, 0);
            Vector3 angles = mainCam.eulerAngles;
            Debug.Log(mainCam.eulerAngles.x);
            if(angles.x > 180 && angles.x < 340 && Input.GetAxis("Vertical") > 0)
            {
                angles = new Vector3(340, angles.y, angles.z);
            }
            else if(angles.x <= 180 && angles.x > 20 && Input.GetAxis("Vertical") <= 0)
            {
                angles = new Vector3(20, angles.y, angles.z);
            }
            else
            {
                mainCam.eulerAngles = new Vector3(angles.x + Input.GetAxis("Vertical") * rotSpeed * -1, angles.y, angles.z);
            }

			if (Input.GetButton ("Jump")) {
				
				moveDir.y = jumpSpeed;
			} else {
				moveDir.y -= gra * Time.deltaTime;
			}
*/
			Debug.Log ("true");
		} else {
			Debug.Log ("false");
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

