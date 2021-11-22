using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStop : MonoBehaviour
{
    private GameObject angle;   //プレイヤー情報格納用
    private Vector3 offset;      //相対距離取得用
   // public float Ypos = 1,Zpos=-10f;

    // Start is called before the first frame update
    void Start()
    {
        //unitychanの情報を取得
        

        // MainCamera(自分自身)とplayerとの相対距離を求める
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y+Ypos, Zpos);

    }

    // Update is called once per frame
    void Update()
    {
        //新しいトランスフォームの値を代入する
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y + Ypos, Zpos); ;

        if (transform.position.y <= -2.5)
        {
            transform.DetachChildren();
        }
    }
}
