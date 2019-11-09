using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player1Ap : MonoBehaviour {
    
    GameObject player1;
    //[SerializeField] GameObject OtherCamera1;
    Slider HP_Slider1;
    public static int MAX_ARMOR_POINT = 100;
	public int armerPoint1;
	public int damage1 = 10;
    CharacterController chCon;
    public Vector3 spawnPosition;

    //スコア表示
    Text point2;
    Text point3;
    Text point4;

    

    // Use this for initialization
    void Start () {
       // audioSources = gameObject.GetComponents<AudioSource>();
        player1 = GameObject.FindWithTag("P1");
        HP_Slider1 = GameObject.FindWithTag("HitPoint1").GetComponent<Slider>();
        point2 = GameObject.FindWithTag("Point2").GetComponent<Text>();
        point3 = GameObject.FindWithTag("Point3").GetComponent<Text>();
        point4 = GameObject.FindWithTag("Point4").GetComponent<Text>();
        chCon = GetComponent<CharacterController> ();
        armerPoint1 = MAX_ARMOR_POINT;
        spawnPosition = player1.transform.position;
        
    }
	
	// Update is called once per frame
	void Update () {

        /*if (RankingSystemScript.Ranking == 1){
            OtherCamera1.SetActive(true);
        }*/

	}

	private void OnCollisionEnter(Collision collider){
		if(collider.gameObject.tag=="Player2Shot"||collider.gameObject.tag=="Player3Shot"
			||collider.gameObject.tag=="Player4Shot"){
            if(collider.gameObject.tag=="Player2Shot"){
                Score.score2 += damage1;
                point2.text = Score.score2.ToString(); 
            }else if(collider.gameObject.tag=="Player3Shot"){
                Score.score3 += damage1;
                point3.text = Score.score3.ToString(); 
            }else{
                Score.score4 += damage1;
                point4.text = Score.score4.ToString(); 
            }
			armerPoint1 -= damage1;
            HP_Slider1.value = armerPoint1;
		}
		if(armerPoint1<=0){
            this.transform.position = spawnPosition;
            armerPoint1 = MAX_ARMOR_POINT;
            HP_Slider1.value = MAX_ARMOR_POINT;
            //audioSources[1].Play();
            //OtherCamera1.SetActive(true);
            //Destroy(player1);

		}

	}
}
