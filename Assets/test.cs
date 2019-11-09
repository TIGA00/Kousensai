using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class test : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GamepadState inSta1 = GamepadInput.GamePad.GetState(GamePad.Index.One);
        GamepadState inSta2 = GamepadInput.GamePad.GetState(GamePad.Index.Two);
        GamepadState inSta3 = GamepadInput.GamePad.GetState(GamePad.Index.Three);
        GamepadState inSta4 = GamepadInput.GamePad.GetState(GamePad.Index.Four);
        if(inSta1.X||inSta1.Y||inSta1.A||inSta1.B){
            Debug.Log("inSta1");
        }else if(inSta2.X||inSta2.Y||inSta2.A||inSta2.B){
             Debug.Log("inSta2");
        }else if(inSta3.X||inSta3.Y||inSta3.A||inSta3.B){
             Debug.Log("inSta3");
        }else if(inSta4.X||inSta4.Y||inSta4.A||inSta4.B){
             Debug.Log("inSta4");
        }
    }
}
