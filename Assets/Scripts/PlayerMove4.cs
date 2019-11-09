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


	public static float BOOST_MAX_CAPACITY = 2.0f;
    public float boostCapacity = BOOST_MAX_CAPACITY;
    public static float ACCELERATE_TIME = 0.5f;
    public float accelerateTime = 0;
    public static float BOOST_COOL_TIME = 1.0f;
    public float boostCoolTime = BOOST_COOL_TIME;
    public bool isBoostCool = false;
    public bool isBoost = false;
	void Start () {
        mainCam = transform.Find("Main Camera4");
        
	}
	
	// Update is called once per frame
	void Update () {
		CharacterController chCon = GetComponent<CharacterController> ();
        GamepadState inSta = GamepadInput.GamePad.GetState(GamePad.Index.One);
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
            //---->ブースト処理
            isBoost = false;
            if(isBoostCool == false) //ブーストがクールタイムに入っているかどうか
            {
                if (inSta.B == true) //ブーストの入力をチェック
                {
                    if (boostCapacity >= 0) //ブーストの容量が残っているかどうか
                    {
                        isBoost = true;
                        if (accelerateTime < ACCELERATE_TIME) //加速時間ないかどうか
                        {
                            boostCapacity -= Time.deltaTime;
                            chCon.Move(transform.forward * boostSpeed * Mathf.Sqrt(accelerateTime) * Time.deltaTime);
                            accelerateTime += Time.deltaTime;
                        }
                        else
                        {
                            chCon.Move(transform.forward * boostSpeed * Mathf.Sqrt(accelerateTime) * Time.deltaTime);
                        }
                        boostCapacity -= Time.deltaTime;
                    }
                    else
                    {
                        isBoostCool = true; //ブーストオーバーヒート
                    }
                }
            } 
            if(isBoostCool || isBoost == false) {
                if (isBoostCool) {
                    if (boostCoolTime >= 0)
                    { //クールタイム内かどうか
                        boostCoolTime -= Time.deltaTime;
                    }
                    else
                    {
                        boostCoolTime = BOOST_COOL_TIME;
                        isBoostCool = false;
                    }
                }
                if(boostCapacity <= BOOST_MAX_CAPACITY) {
                    boostCapacity += Time.deltaTime * 3;
                }
            }

            if (inSta.B == false)
            {
                accelerateTime = 0;
            }
			//ブースト処理<-------

			if (inSta.X == true) {
				moveDir = new Vector3 (0, 0, 1);
			} else if (inSta.Y) {
				moveDir = new Vector3 (0, 0, -1);
			} else if (inSta.X == false && inSta.Y == false) {
				moveDir = new Vector3 (0, 0, 0);
			}
			moveDir = transform.TransformDirection (moveDir);
			moveDir *= speed;
			//transform.Rotate (0, GamePad.GetAxis(GamePad.Axis.LeftStick,GamePad.Index.Four).x * rotSpeed, 0);
			transform.Rotate (0, Input.GetAxis("Horizontal_4") * rotSpeed, 0);
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
