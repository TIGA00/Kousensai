using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player4Ap : MonoBehaviour {
   // [SerializeField] GameObject OtherCamera4;
    GameObject player4;
    Slider HP_Slider4;
    public static int MAX_ARMOR_POINT = 100;
	public int armerPoint4;
	public int damage4 = 10;
    CharacterController chCon;
    public Vector3 spawnPosition;
    

    //スコア表示
    Text point1;
    Text point2;
    Text point3;
    void Start () {
        //audioSources = gameObject.GetComponents<AudioSource>();
        player4 = GameObject.FindWithTag("P4");
        HP_Slider4 = GameObject.FindWithTag("HitPoint4").GetComponent<Slider>();
        point1 = GameObject.FindWithTag("Point1").GetComponent<Text>();
        point2 = GameObject.FindWithTag("Point2").GetComponent<Text>();
        point3 = GameObject.FindWithTag("Point3").GetComponent<Text>();
        armerPoint4 = MAX_ARMOR_POINT;
        chCon = GetComponent<CharacterController> ();
        spawnPosition = player4.transform.position;
	}

	// Update is called once per frame
	void Update () {
       /* if (RankingSystemScript.Ranking == 1)
        {
            OtherCamera4.SetActive(true); 
        }*/
	}
	private void OnCollisionEnter(Collision collider){
		if(collider.gameObject.tag=="Player2Shot"||collider.gameObject.tag=="Player3Shot"
			||collider.gameObject.tag=="Player1Shot"){
            if(collider.gameObject.tag=="Player2Shot"){
                Score.score2 += damage4;
                point2.text = Score.score2.ToString(); 
            }else if(collider.gameObject.tag=="Player3Shot"){
                Score.score3 += damage4;
                point3.text = Score.score3.ToString(); 
            }else{
                Score.score1 += damage4;
                point1.text = Score.score1.ToString(); 
            }
			armerPoint4 -= damage4;
            HP_Slider4.value = armerPoint4;
		}
		if(armerPoint4<=0){
            this.transform.position = spawnPosition;
            HP_Slider4.value =armerPoint4 = MAX_ARMOR_POINT;
		}
	}
}
