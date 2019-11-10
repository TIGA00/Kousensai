using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;
using UnityEngine.UI;
public class PlayerMove2 : MonoBehaviour {
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


	public static float BOOST_MAX_CAPACITY = 200.0f;
    public float boostCapacity = BOOST_MAX_CAPACITY;
    public static float ACCELERATE_TIME = 0.15f;
    public float accelerateTime = 0;
    public static float BOOST_COOL_TIME = 1.0f;
    public float boostCoolTime = BOOST_COOL_TIME;
    public bool isBoostCool = false;
    public bool isBoost = false;

	Slider Boost_Slider2;

	void Start () {
        mainCam = transform.Find("Main Camera2");
        Boost_Slider2 = GameObject.FindWithTag("boost_p2").GetComponent<Slider>();
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
			//---->ブースト処理
            isBoost = false;
            if(isBoostCool == false) //ブーストがクールタイムに入っているかどうか
            {
                if (inSta.B == true) //ブーストの入力をチェック
                {
                    Debug.Log("ブースと");
                    if (boostCapacity >= 0) //ブーストの容量が残っているかどうか
                    {
                        Debug.Log("ブースと2");
                        isBoost = true;
                        if (accelerateTime < ACCELERATE_TIME) //加速時間ないかどうか
                        {
                            Debug.Log("ブースと3");
                            boostCapacity -= 100*Time.deltaTime;
							Boost_Slider2.value = boostCapacity;
                            chCon.Move(transform.forward * boostSpeed * accelerateTime * Time.deltaTime);
                            accelerateTime += Time.deltaTime;
                        }
                        else
                        {
                            Debug.Log("ブースと4");
                            //Debug.Log(transform.forward);
                            //Debug.Log(mainCam.transform.forward * boostSpeed * accelerateTime * 10 * Time.deltaTime);
                            chCon.Move(transform.forward * boostSpeed * accelerateTime * 10 * Time.deltaTime);
                        }
                        boostCapacity -= 100*Time.deltaTime;
						Boost_Slider2.value = boostCapacity;
                    }
                    else
                    {
                        Debug.Log("オーバーヒート");
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
                    boostCapacity += 100* Time.deltaTime * 3;
					Boost_Slider2.value = boostCapacity;
                }
            }

            if (inSta.B == false)
            {
                accelerateTime = 0;
            }
			//---->ブースト処理

			if (inSta.X == true) {
				moveDir = new Vector3 (0, 0, 1);
			} else if (inSta.Y) {
				moveDir = new Vector3 (0, 0, -1);
			} else if (inSta.X == false && inSta.Y == false) {
				moveDir = new Vector3 (0, 0, 0);
			}
			moveDir = transform.TransformDirection (moveDir);
			moveDir *= speed;			
            //transform.Rotate(0, GamePad.GetAxis(GamePad.Axis.LeftStick, GamePad.Index.Two).x * rotSpeed, 0);
			transform.Rotate (0, Input.GetAxis("Horizontal_2") * 0.5f * rotSpeed, 0);
			Vector3 angles = mainCam.eulerAngles;
            if (angles.x > 180 && angles.x < 340 && Input.GetAxis("Vertical_2") > 0)
			{
				angles = new Vector3(340, angles.y, angles.z);
			}
			else if(angles.x <= 180 && angles.x > 20 && Input.GetAxis("Vertical_2") <= 0)
			{
				angles = new Vector3(20, angles.y, angles.z);
			}
			else
			{
				mainCam.eulerAngles = new Vector3(angles.x + Input.GetAxis("Vertical_2") * rotSpeed * -1, angles.y, angles.z);
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
