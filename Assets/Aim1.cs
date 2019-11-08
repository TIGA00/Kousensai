using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 追加しましょう（ポイント）
using UnityEngine.UI;
 
public class Aim1 : MonoBehaviour {

    public static float lockOn1 = 0;
 
    // 照準のImageをインスペクターから設定
    [SerializeField]
    private Image aimPointImage;
 
    void Update () {
 
        // Rayを飛ばす（第1引数がRayの発射座標、第2引数がRayの向き）
        Ray ray = new Ray (transform.position, transform.forward);
 
        // outパラメータ用に、Rayのヒット情報を取得するための変数を用意
        RaycastHit hit;
 
        // シーンビューにRayを可視化するデバッグ（必要がなければ消してOK）
        Debug.DrawRay(ray.origin, ray.direction * 30.0f, Color.red, 0.0f);
 
        // Rayのhit情報を取得する
        if (Physics.SphereCast(ray,8f, out hit, 1000f)) {
            Debug.DrawRay (ray.origin, ray.direction * 10f, Color.red, 5f, false);
 
            // Rayがhitしたオブジェクトのタグ名を取得
            string hitTag = hit.collider.tag;
 
            // タグの名前がEnemyだったら、照準の色が変わる
            if ((hitTag.Equals("bunkasai_player(1)"))) {
                //照準を赤に変える
                aimPointImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                //2Pロックオン
                lockOn1 = 2;
            }else if ((hitTag.Equals("bunkasai_player(2)"))) {
                //照準を赤に変える
                aimPointImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                //3Pロックオン
                lockOn1 = 3;
            }else if ((hitTag.Equals("bunkasai_player(3)"))) {
                //照準を赤に変える
                aimPointImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                //4Pロックオン
                lockOn1 = 4;
            }else {
                // Enemy以外では水色に
                aimPointImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
                lockOn1 = 0;
            }
                     
        } else {
            // Rayがヒットしていない場合は水色に
            aimPointImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
