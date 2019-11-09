using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    public static int score1;
    public static int score2;
    public static int score3;
    public static int score4;
    // Start is called before the first frame update
    void Start()
    {
        score1 = 0;
        score2 = 0;
        score3 = 0;
        score4 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*Debug.Log("score1 : " + score1);
        Debug.Log("score2 : " + score2);
        Debug.Log("score3 : " + score3);
        Debug.Log("score4 : " + score4);*/
    }
}
