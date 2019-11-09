﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Shooting02 : MonoBehaviour {
 
    // bullet prefab
    //追尾しないやつ
    public GameObject bullet0;
    //1P追尾用
    public GameObject bullet1;
    //3P追尾用
    public GameObject bullet3;
    //4P追尾用
    public GameObject bullet4;
 
    // 弾丸発射点
    public Transform gun;

    //カメラ
    public Transform Camera;
 
    // 弾丸の速度
    public float speed = 1000;

    //連射設定
    private float timeBetweenShot = 0.35f;
    private float timer;
 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        // タイマーの時間を動かす
        timer += Time.deltaTime;

        // c キーが押された時
        if (Input.GetButton("Button2") && timer > timeBetweenShot){
            timer = 0.0f;

            if(Aim2.lockOn2 == 1){
                // 弾丸の複製
                GameObject bullets = Instantiate(bullet1,gun.transform.position, Camera.transform.rotation);
    
                Vector3 force;
    
                force = this.gameObject.transform.forward * speed;
    
                // Rigidbodyに力を加えて発射
                bullet1.GetComponent<Rigidbody>().AddForce(force);
    
                // 弾丸の位置を調整
                //bullets.transform.position = muzzle.position;
            }else if(Aim2.lockOn2 == 3){
                // 弾丸の複製
                GameObject bullets = Instantiate(bullet3,gun.transform.position, Camera.transform.rotation);
    
                Vector3 force;
    
                force = this.gameObject.transform.forward * speed;
    
                // Rigidbodyに力を加えて発射
                bullet3.GetComponent<Rigidbody>().AddForce(force);
    
                // 弾丸の位置を調整
                //bullets.transform.position = muzzle.position;
            }else if(Aim2.lockOn2 == 4){
                // 弾丸の複製
                GameObject bullets = Instantiate(bullet4,gun.transform.position, Camera.transform.rotation);
    
                Vector3 force;
    
                force = this.gameObject.transform.forward * speed;
    
                // Rigidbodyに力を加えて発射
                bullet4.GetComponent<Rigidbody>().AddForce(force);
    
                // 弾丸の位置を調整
                //bullets.transform.position = muzzle.position;
            }else{
                // 弾丸の複製
            GameObject bullets = Instantiate(bullet0,gun.transform.position, Camera.transform.rotation);
 
            Vector3 force;
 
            force = this.gameObject.transform.forward * speed;
 
            // Rigidbodyに力を加えて発射
            bullet0.GetComponent<Rigidbody>().AddForce(force);
 
            // 弾丸の位置を調整
            //bullets.transform.position = muzzle.position;
            }
            
        }
		
	}
}