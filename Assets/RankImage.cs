using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RankImage : MonoBehaviour {

    [SerializeField] GameObject Rank01;
    [SerializeField] GameObject Rank02;
    [SerializeField] GameObject Rank03;
    [SerializeField] GameObject Rank04;

    RankingSystemScript RankingSystem;


	// Use this for initialization
	void Start () {
        if (RankingSystemScript.Ranking == 4)
        {
            Rank04.SetActive(true);
            RankingSystemScript.Ranking -= 1;
        }
        else if (RankingSystemScript.Ranking == 3)
        {
            Rank03.SetActive(true);
            RankingSystemScript.Ranking -= 1;
        }
        else if (RankingSystemScript.Ranking == 2)
        {
            Rank02.SetActive(true);
            RankingSystemScript.Ranking -= 1;
        }
        else if (RankingSystemScript.Ranking == 1)
        {
            Rank01.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {

	}

    /* private void OnEnable()
    {
        if(GetComponent<RankingScript>().Ranking == 4){
            Rank04.SetActive(true);
            GetComponent<RankingScript>().Ranking -= 1;
        }else if(GetComponent<RankingScript>().Ranking == 3){
            Rank03.SetActive(true);
            GetComponent<RankingScript>().Ranking -= 1;
        }else if(GetComponent<RankingScript>().Ranking == 2){
            Rank02.SetActive(true);
            GetComponent<RankingScript>().Ranking -= 1;
        }else if(GetComponent<RankingScript>().Ranking == 1){
            Rank01.SetActive(true);
        }
    }*/


}
