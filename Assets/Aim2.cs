using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 追加しましょう（ポイント）
using UnityEngine.UI;
 
public class Aim2 : MonoBehaviour {

    public static float lockOn2 = 0;
 
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
        if (Physics.SphereCast(ray,8f, out hit, 500f)) {
 
            // Rayがhitしたオブジェクトのタグ名を取得
            string hitTag = hit.collider.tag;
 
            // タグの名前がEnemyだったら、照準の色が変わる
            if ((hitTag.Equals("bunkasai_player"))) {
                //照準を赤に変える
                aimPointImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                //1Pロックオン
                lockOn2 = 1;
            }else if ((hitTag.Equals("bunkasai_player(2)"))) {
                //照準を赤に変える
                aimPointImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                //3Pロックオン
                lockOn2 = 3;
            }else if ((hitTag.Equals("bunkasai_player(3)"))) {
                //照準を赤に変える
                aimPointImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                //4Pロックオン
                lockOn2 = 4;
            }else {
                // Enemy以外では水色に
                aimPointImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
                lockOn2 = 0;
            }
                     
        } else {
            // Rayがヒットしていない場合は水色に
            aimPointImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
