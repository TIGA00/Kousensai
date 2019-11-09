using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player3Ap : MonoBehaviour {
   // [SerializeField] GameObject OtherCamera3;
    GameObject player3;
    Slider HP_Slider3;
	public int armerPoint3 = 100;
	public int damage3 = 10;
    //private AudioSource[] audioSources;
    // Use this for initialization
    void Start () {
      //  audioSources = gameObject.GetComponents<AudioSource>();
        player3 = GameObject.FindWithTag("P3");
        HP_Slider3 = GameObject.FindWithTag("HitPoint3").GetComponent<Slider>();
        armerPoint3 = 1000;
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
          
		}
		/*if(armerPoint3<=0){
            audioSources[1].Play();
            OtherCamera3.SetActive(true);
			Destroy(player3);
		}*/
	}
}
