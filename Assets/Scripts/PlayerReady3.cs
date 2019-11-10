﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamepadInput;

public class PlayerReady3 : MonoBehaviour {
    Image readyImage;
    Image OKImage;
    bool isWaited = false;

    // Use this for initialization
    void Start () {
        GetComponent<Motion3>().enabled = false;
        GetComponent<PlayerMove3>().enabled = false;
        //readyImage = GameObject.Find("AreYouReady").GetComponent<Image>();
        //OKImage = GameObject.Find("OK").GetComponent<Image>();
        //OKImage.enabled = false;
        //readyImage.enabled = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        GamepadState inSta = GamepadInput.GamePad.GetState(GamePad.Index.Two);
        if (isWaited == false){
			if (inSta.X||inSta.Y||inSta.A||inSta.B) {
                GameReady();
            }
        }
        if(GameSystem.isGameStarted == true){
            GameStart();
            this.enabled = false;
        }
	}

    void GameReady()
    {
        isWaited = true;
        //OKImage.enabled = true;
        //readyImage.enabled = false;
        GameSystem.ready ++;
    }

    void GameStart()
    {
        GetComponent<Motion3>().enabled = true;
        GetComponent<PlayerMove3>().enabled = true;
        //OKImage.enabled = false;
        //readyImage.enabled = false;
    }
}
