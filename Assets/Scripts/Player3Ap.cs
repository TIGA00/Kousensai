using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player3Ap : MonoBehaviour {
   // [SerializeField] GameObject OtherCamera3;
    GameObject player3;
    Slider HP_Slider3;
    public static int MAX_ARMOR_POINT = 100;
	public int armerPoint3;
	public int damage3 = 10;
    CharacterController chCon;
    public Vector3 spawnPosition;


    //スコア表示
    Text point1;
    Text point2;
    Text point4;

    void Start () {
      //  audioSources = gameObject.GetComponents<AudioSource>();
        player3 = GameObject.FindWithTag("P3");
        HP_Slider3 = GameObject.FindWithTag("HitPoint3").GetComponent<Slider>();
        armerPoint3 = MAX_ARMOR_POINT;
        point1 = GameObject.FindWithTag("Point1").GetComponent<Text>();
        point2 = GameObject.FindWithTag("Point2").GetComponent<Text>();
        point4 = GameObject.FindWithTag("Point4").GetComponent<Text>();
        chCon = GetComponent<CharacterController> ();
        spawnPosition = player3.transform.position;
	}

	// Update is called once per frame
	void Update () {
        /*if (RankingSystemScript.Ranking == 1)
        {
            OtherCamera3.SetActive(true); 
        }*/
	}
	private void OnCollisionEnter(Collision collider){
		if(collider.gameObject.tag=="Player2Shot"||collider.gameObject.tag=="Player4Shot"
			||collider.gameObject.tag=="Player1Shot"){
			armerPoint3 -= damage3;
            HP_Slider3.value = armerPoint3;
            if(collider.gameObject.tag=="Player2Shot"){
                Score.score2 += damage3;
                point2.text = Score.score2.ToString(); 
            }else if(collider.gameObject.tag=="Player4Shot"){
                Score.score4 += damage3;
                point4.text = Score.score4.ToString(); 
            }else{
                Score.score1 += damage3;
                point1.text = Score.score1.ToString(); 
            }
		}
		if(armerPoint3<=0){
            this.transform.position = spawnPosition;
            HP_Slider3.value =armerPoint3 = MAX_ARMOR_POINT;
		}
	}
}
