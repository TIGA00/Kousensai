using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamepadInput;

public class PlayerReady : MonoBehaviour {
    Image readyImage;
    Image OKImage;
    bool isWaited = false;

    // Use this for initialization
    void Start () {
        GetComponent<PlayerMotion>().enabled = false;
        GetComponent<PlayerMove>().enabled = false;
        readyImage = GameObject.Find("AreYouReady").GetComponent<Image>();
        OKImage = GameObject.Find("OK").GetComponent<Image>();
        OKImage.enabled = false;
        readyImage.enabled = true;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (isWaited == false){
			if (GamePad.GetButtonUp(GamePad.Button.A, GamePad.Index.One)||GamePad.GetAxis(GamePad.Axis.LeftStick,GamePad.Index.One).x>0) {
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
        OKImage.enabled = true;
        readyImage.enabled = false;
        GameSystem.ready ++;
    }

    void GameStart()
    {
        GetComponent<PlayerMotion>().enabled = true;
        GetComponent<PlayerMove>().enabled = true;
        OKImage.enabled = false;
        readyImage.enabled = false;
    }
}
