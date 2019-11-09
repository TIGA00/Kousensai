using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour {
    public static int ready = 0; //準備完了した人数
    public static bool isGameStarted = false; //テスト時true, 本番時false
    private AudioSource[] audioSources; //複数の音楽ファイルを追加した時に対応できるように配列

	// Use this for initialization
	void Start () {
        audioSources = gameObject.GetComponents<AudioSource>();
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
    }
}
