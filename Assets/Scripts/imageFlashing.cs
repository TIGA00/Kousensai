using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imageFlashing : MonoBehaviour {
    public Image image;
    public float flashSpeed = 10f;
    private float time;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        image.color = colorChange(image.color);
	}
    
    private Color colorChange(Color color){
        time += Time.deltaTime * 5.0F * flashSpeed;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f;
        return color;

    }
}
