using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour {
    public static int ready = 0; //準備完了した人数
    public static bool isGameStarted = false; //テスト時true, 本番時false
    public static float game_time = 180f;
    private AudioSource[] audioSources; //複数の音楽ファイルを追加した時に対応できるように配列
    Text timeText1;
    Text timeText2;
    Text timeText3;
    Text timeText4;
    Image resultBackground1;
    Image resultBackground2;
    Image resultBackground3;
    Image resultBackground4;
    Image takenaka1;
    Image takenaka2;
    Image takenaka3;
    Image takenaka4;
    Text rank1;
    Text rank2;
    Text rank3;
    Text rank4;


	// Use this for initialization
	void Start () {
        audioSources = gameObject.GetComponents<AudioSource>();
        timeText1 = GameObject.FindWithTag("GameTime1").GetComponent<Text>();
        timeText2 = GameObject.FindWithTag("GameTime2").GetComponent<Text>();
        timeText3 = GameObject.FindWithTag("GameTime3").GetComponent<Text>();
        timeText4 = GameObject.FindWithTag("GameTime4").GetComponent<Text>();
        resultBackground1 = GameObject.FindWithTag("ResultBackground1").GetComponent<Image>();
        resultBackground2 = GameObject.FindWithTag("ResultBackground2").GetComponent<Image>();
        resultBackground3 = GameObject.FindWithTag("ResultBackground3").GetComponent<Image>();
        resultBackground4 = GameObject.FindWithTag("ResultBackground4").GetComponent<Image>();
        resultBackground1.enabled = false;
        resultBackground2.enabled = false;
        resultBackground3.enabled = false;
        resultBackground4.enabled = false;
        takenaka1 = GameObject.FindWithTag("Takenaka1").GetComponent<Image>();
        takenaka2 = GameObject.FindWithTag("Takenaka2").GetComponent<Image>();
        takenaka3 = GameObject.FindWithTag("Takenaka3").GetComponent<Image>();
        takenaka4 = GameObject.FindWithTag("Takenaka4").GetComponent<Image>();
        takenaka1.enabled = false;
        takenaka2.enabled = false;
        takenaka3.enabled = false;
        takenaka4.enabled = false;
        rank1 = GameObject.FindWithTag("Rank1").GetComponent<Text>();
        rank2 = GameObject.FindWithTag("Rank2").GetComponent<Text>();
        rank3 = GameObject.FindWithTag("Rank3").GetComponent<Text>();
        rank4 = GameObject.FindWithTag("Rank4").GetComponent<Text>();
        rank1.enabled = false;
        rank2.enabled = false;
        rank3.enabled = false;
        rank4.enabled = false;
        audioSources[0].Play();
    }
	
	// Update is called once per frame
	void Update () {
       if(isGameStarted == false){
            if(ready == 4){
               isGameStarted = true;
            }
        }
        if(!audioSources[0].isPlaying){
            audioSources[0].Play();
        }
        if(isGameStarted){
            game_time -= Time.deltaTime;
            timeText1.text = "のこり"+((int)game_time).ToString()+"秒";
            timeText2.text = "のこり"+((int)game_time).ToString()+"秒";
            timeText3.text = "のこり"+((int)game_time).ToString()+"秒";
            timeText4.text = "のこり"+((int)game_time).ToString()+"秒";
        }
        if((int)game_time == 0){
            resultBackground1.enabled = true;
            resultBackground2.enabled = true;
            resultBackground3.enabled = true;
            resultBackground4.enabled = true;
            takenaka1.enabled = true;
            takenaka2.enabled = true;
            takenaka3.enabled = true;
            takenaka4.enabled = true;
            rank1.enabled = true;
            rank2.enabled = true;
            rank3.enabled = true;
            rank4.enabled = true;
            int[] score = new int[4];
            int[] ran1 = new int[4];
            int[] ran2 = new int[4];
            score[0] = Score.score1;
            score[1] = Score.score2;
            score[2] = Score.score3;
            score[3] = Score.score4;
            for(int i = 0;i < 4;i++)ran1[i] = i+1;
            for(int i = 0;i < 4;i++){
                for(int j = 2;j >= 0;j--){
                    if(score[j] < score[j+1]){
                        int tmp1 = score[j];
                        score[j] = score[j+1];
                        score[j+1] = tmp1;

                        int tmp2 = ran1[j];
                        ran1[j] = ran1[j+1];
                        ran1[j+1] = tmp2;
                    }
                }
            }
            for(int i = 0;i < 4;i++)ran2[ran1[i]-1] = i+1;
            rank1.text = "#"+ran2[0].ToString();
            rank2.text = "#"+ran2[1].ToString();
            rank3.text = "#"+ran2[2].ToString();
            rank4.text = "#"+ran2[3].ToString();
        }
        if (Input.GetKeyUp(KeyCode.Space)) {
            audioSources[0].Stop();
			Application.LoadLevel ("title");
		}
    }
}
