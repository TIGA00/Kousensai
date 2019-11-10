using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2Ap : MonoBehaviour {

    //[SerializeField] GameObject OtherCamera2;

    GameObject player2;
    Slider HP_Slider2;
    public static int MAX_ARMOR_POINT = 100;
	public int armerPoint2;
	public int damage2 = 10;
    CharacterController chCon;
    public Vector3 spawnPosition;

    //スコア表示
    Text point1;
    Text point3;
    Text point4;

	// Use this for initialization

    void Start () {
      //  audioSources = gameObject.GetComponents<AudioSource>();
        player2 = GameObject.FindWithTag("P2");
        HP_Slider2 = GameObject.FindWithTag("HitPoint2").GetComponent<Slider>();
        point1 = GameObject.FindWithTag("Point1").GetComponent<Text>();
        point3 = GameObject.FindWithTag("Point3").GetComponent<Text>();
        point4 = GameObject.FindWithTag("Point4").GetComponent<Text>();
        armerPoint2 = MAX_ARMOR_POINT;
        chCon = GetComponent<CharacterController> ();
        spawnPosition = player2.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        /*if (RankingSystemScript.Ranking == 1)
        {
            OtherCamera2.SetActive(true); 
        }*/
	}
	private void OnCollisionEnter(Collision collider){
		if(collider.gameObject.tag=="Player1Shot"||collider.gameObject.tag=="Player3Shot"
			||collider.gameObject.tag=="Player4Shot"){
            if(collider.gameObject.tag=="Player1Shot"){
                Score.score1 += damage2;
                point1.text = Score.score1.ToString();
            }else if(collider.gameObject.tag=="Player3Shot"){
                Score.score3 += damage2;
                point3.text = Score.score3.ToString();
            }else{
                Score.score4 += damage2;
                point4.text = Score.score4.ToString();
            }
			armerPoint2 -= damage2;
            HP_Slider2.value = armerPoint2;
		}

		if(armerPoint2<=0){
            this.transform.position = spawnPosition;
            HP_Slider2.value = armerPoint2 = MAX_ARMOR_POINT; 
		}
	}
}
