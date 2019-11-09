using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player4Ap : MonoBehaviour {
   // [SerializeField] GameObject OtherCamera4;
    GameObject player4;
    Slider HP_Slider4;
	public int armerPoint4 = 1000;
	public int damage4 = 10;
   // private AudioSource[] audioSources;
    // Use this for initialization
    void Start () {
        //audioSources = gameObject.GetComponents<AudioSource>();
        player4 = GameObject.FindWithTag("P4");
        HP_Slider4 = GameObject.FindWithTag("HitPoint4").GetComponent<Slider>();
        armerPoint4 = 100;
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
			armerPoint4 -= damage4;
            HP_Slider4.value = armerPoint4;

		}
		/*if(armerPoint4<=0){
            audioSources[1].Play();
            OtherCamera4.SetActive(true);
			Destroy(player4);
		}*/
	}
}
