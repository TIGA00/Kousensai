using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class titleTransition : MonoBehaviour {

    private AudioSource[] audioSources;

	// Use this for initialization
	void Start () {
        audioSources = gameObject.GetComponents<AudioSource>();
       // audioSources[0].Play();
    }
	
	// Update is called once per frame
	void Update () {
		GamepadState inSta1 = GamepadInput.GamePad.GetState(GamePad.Index.One);
		GamepadState inSta2 = GamepadInput.GamePad.GetState(GamePad.Index.Two);
		GamepadState inSta3 = GamepadInput.GamePad.GetState(GamePad.Index.Three);
		GamepadState inSta4 = GamepadInput.GamePad.GetState(GamePad.Index.Four);
        if (!audioSources[0].isPlaying) {
           // audioSources[0].Play();
        }
        if (inSta1.A == true || inSta1.B == true || inSta1.X == true) {
            audioSources[0].Stop();
			Application.LoadLevel ("SampleScene");
		}
	}
}
