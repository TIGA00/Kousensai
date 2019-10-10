using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player1Ap : MonoBehaviour {
    
    GameObject player1;
    [SerializeField] GameObject OtherCamera1;
    Slider HP_Slider1;
	public int armerPoint1 = 100;
	public int damage1 = 10;
    private AudioSource[] audioSources;

    // Use this for initialization
    void Start () {
        audioSources = gameObject.GetComponents<AudioSource>();
        player1 = GameObject.FindWithTag("bunkasai_player");
        HP_Slider1 = GameObject.FindWithTag("HitPoint1").GetComponent<Slider>();
        armerPoint1 = 100;
    }
	
	// Update is called once per frame
	void Update () {

        if (RankingSystemScript.Ranking == 1){
            OtherCamera1.SetActive(true);
        }

	}

	private void OnCollisionEnter(Collision collider){
		if(collider.gameObject.tag=="Player2Shot"||collider.gameObject.tag=="Player3Shot"
			||collider.gameObject.tag=="Player4Shot"){
			armerPoint1 -= damage1;
            HP_Slider1.value = armerPoint1;
		}
		if(armerPoint1<=0){
            audioSources[1].Play();
            OtherCamera1.SetActive(true);
            Destroy(player1);

		}

	}
}
